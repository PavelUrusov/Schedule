using System.Net;
using Moq;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;
using WorkSchedule.DataAccessLayer.Entities;
using Xunit;

namespace WorkSchedule.Tests.EmployeeManagerTests;

public sealed class AddEmployeeAsync : BaseEmployeeManagerMock
{
    private readonly RequestAddEmployeeDto _dto;
    private readonly int _userId;

    public AddEmployeeAsync()
    {
        _dto = new RequestAddEmployeeDto
        {
            WorkObject = new RequestGetWorkObjectDto
            {
                WorkObjectId = 1
            },
            Firstname = "John",
            Surname = "Doe",
            Lastname = "Smith"
        };
        _userId = 1;
    }

    [Fact]
    public async Task AddEmployeeAsync_ReturnsResponseBaseWithOk_WhenWorkObjectFound()
    {
        // Arrange
        var expectedResult = new ResponseBase();
        var expectedResultGetWorkObject = new ResponseBase();
        _woServiceMock.Setup(x => x.GetWorkObjectAsync(_dto.WorkObject, _userId))
            .ReturnsAsync(expectedResultGetWorkObject);

        // Act
        var actualResult = await _employeeManager.AddEmployeeAsync(_dto, _userId);

        // Assert
        _empRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Employee>()), Times.Once);
        Assert.Equal(expectedResult.IsSuccessful, actualResult.IsSuccessful);
    }

    [Fact]
    public async Task AddEmployeeAsync_ReturnsResponseBaseWithBadRequest_WhenWorkObjectNotFound()
    {
        // Arrange
        var expectedResult = new ResponseBase { HttpStatusCode = HttpStatusCode.BadRequest };
        var expectedResultGetWorkObject = new ResponseBase { HttpStatusCode = HttpStatusCode.BadRequest };
        _woServiceMock.Setup(x => x.GetWorkObjectAsync(_dto.WorkObject, _userId)).ReturnsAsync(expectedResultGetWorkObject);

        // Act
        var actualResult = await _employeeManager.AddEmployeeAsync(_dto, _userId);

        // Assert
        _empRepositoryMock.Verify(x => x.InsertRangeAsync(It.IsAny<IEnumerable<Employee>>()), Times.Never);
        Assert.Equal(expectedResult.IsSuccessful, actualResult.IsSuccessful);
    }
}