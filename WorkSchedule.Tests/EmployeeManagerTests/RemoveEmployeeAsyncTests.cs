using Moq;
using System.Linq.Expressions;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.DataAccessLayer.Entities;
using Xunit;
using System.Net;

namespace WorkSchedule.Tests.EmployeeManagerTests
{
    public class RemoveEmployeeAsyncTests:BaseEmployeeManagerMock
    {
        private readonly RequestRemoveEmployeeDto _dto;
        private readonly int _userId;
        public RemoveEmployeeAsyncTests()
        {
            // Arrange
            _dto = new RequestRemoveEmployeeDto { Id = 1 };
            _userId = 1;
        }
        [Fact]
        public async Task RemoveEmployeeAsync_RemovesEmployee_WhenEmployeeExists()
        {
            var expectedResult = new ResponseBase();
            var expectedResultSingleOrDefault = new Employee { Id = 1, WorkObject = new WorkObject { UserId = _userId } };
            _empRepositoryMock.Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<Employee, bool>>>()!))
                .ReturnsAsync(expectedResultSingleOrDefault);

            // Act
            var actualResult = await _employeeManager.RemoveEmployeeAsync(_dto, _userId);

            // Assert
            _empRepositoryMock.Verify(x => x.DeleteAsync(expectedResultSingleOrDefault), Times.Once);
            Assert.Equal(expectedResult.IsSuccessful,actualResult.IsSuccessful);
        }

        [Fact]
        public async Task RemoveEmployeeAsync_ReturnsErrorResponse_WhenEmployeeNotFound()
        {
            // Arrange
            var expectedResult = new ResponseBase { HttpStatusCode = HttpStatusCode.BadRequest };
            Employee? expectedResultSingleOrDefault = null;
            _empRepositoryMock.Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<Employee, bool>>>()!))
                .ReturnsAsync(expectedResultSingleOrDefault);

            // Act
            var actualResult = await _employeeManager.RemoveEmployeeAsync(_dto, _userId);

            // Assert
            _empRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Never);
            Assert.Equal(expectedResult.IsSuccessful, actualResult.IsSuccessful);
        }
    }
}