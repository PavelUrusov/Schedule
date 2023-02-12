using System.Net;
using AutoMapper;
using Moq;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;
using Xunit;

namespace WorkSchedule.Tests.EmployeeManagerTests;

public class RemoveListEmployeeAsyncTests 
{
    private readonly EmployeeManager _employeeManager;
    private readonly Mock<IWorkScheduleRepository<Employee, int>> _employeeRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IWorkObjectService> _woServiceMock;

    public RemoveListEmployeeAsyncTests()
    {
        _employeeRepositoryMock = new Mock<IWorkScheduleRepository<Employee, int>>();
        _mapperMock = new Mock<IMapper>();
        _woServiceMock = new Mock<IWorkObjectService>();
        _employeeManager = new EmployeeManager(_employeeRepositoryMock.Object, _mapperMock.Object,
            _woServiceMock.Object);
    }

    [Fact]
    public async Task Test_RemoveListEmployeeAsync_ShouldReturnBadRequest_WhenListContainsNonExistentEmployees()
    {
        // Arrange
        var employees = new List<Employee> {
            new Employee { Id = 1, WorkObject = new WorkObject { UserId = 1 } },
            new Employee { Id = 2, WorkObject = new WorkObject { UserId = 2 } },
            new Employee { Id = 3, WorkObject = new WorkObject { UserId = 1 } },
        };

        _employeeRepositoryMock.Setup(r => r.CreateQueryable())
            .Returns(employees.AsQueryable());

        _employeeRepositoryMock.Setup(r => r.DeleteRangeAsync(It.IsAny<List<Employee>>()))
            .Returns(Task.CompletedTask);

        var dto = new RequestRemoveListEmployeeDto
        {
            Employees = new List<RequestRemoveEmployeeDto> {
                new RequestRemoveEmployeeDto { Id = 1 },
                new RequestRemoveEmployeeDto { Id = 2 },
                new RequestRemoveEmployeeDto { Id = 4 },
            }
        };

        var manager = new EmployeeManager(_employeeRepositoryMock.Object, _mapperMock.Object, _woServiceMock.Object);

        // Act
        var result = await manager.RemoveListEmployeeAsync(dto, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.BadRequest, result.HttpStatusCode);
        Assert.Equal("The list contains non-existent employees", result.ErrorMessage);
    }

    /*
    [Fact]
    public async Task RemoveListEmployeeAsync_RemovesEmployees_WhenRepositoryReturnsEmployees()
    {
        // Arrange
        var mockEmpRepository = new Mock<IWorkScheduleRepository<Employee, int>>();
        var mockMapper = new Mock<IMapper>();
        var mockWoService = new Mock<IWorkObjectService>();
        var employeeManager = new EmployeeManager(mockEmpRepository.Object, mockMapper.Object, mockWoService.Object);
        var requestDto = new RequestRemoveListEmployeeDto
        {
            Employees = new List<RequestRemoveEmployeeDto>
            {
                new (){ Id = 1 },
                new (){ Id = 2 },
                new () { Id = 3 }
            }
        };
        var userId = 1;
        var employees = new List<Employee>
        {
            new Employee { Id = 1, WorkObject = new WorkObject { UserId = 1 } },
            new Employee { Id = 2, WorkObject = new WorkObject { UserId = 1 } },
            new Employee { Id = 3, WorkObject = new WorkObject { UserId = 1 } }
        };

        mockEmpRepository
            .Setup(repo => repo.CreateQueryable())
            .Returns(employees.AsQueryable());

        mockEmpRepository
            .Setup(repo => repo.DeleteRangeAsync(It.IsAny<IEnumerable<Employee>>()))
            .Returns(Task.CompletedTask);

        // Act
        var response = await employeeManager.RemoveListEmployeeAsync(requestDto, userId);

        // Assert
        mockEmpRepository.Verify(repo => repo.DeleteRangeAsync(employees), Times.Once);
        Assert.IsType<ResponseBase>(response);
    }
    */


    /*
    [Fact]
    public async Task RemoveListEmployeeAsync_DoesNotRemoveEmployees_WhenRepositoryReturnsNoEmployees()
    {
        // Arrange
        var list = new List<Employee>().AsQueryable();
        _empRepositoryMock.Setup(r => r.CreateQueryable().Where(It.IsAny<Expression<Func<Employee, bool>>>())).Returns(list);


        // Act
        var result = await _employeeManager.RemoveListEmployeeAsync(_dto, _userId);

        // Assert
        Assert.NotEqual(HttpStatusCode.OK, result.HttpStatusCode);
        mockEmpRepository.Verify(r => r.DeleteRangeAsync(It.IsAny<IEnumerable<Employee>>()), Times.Never);
    }*/
}