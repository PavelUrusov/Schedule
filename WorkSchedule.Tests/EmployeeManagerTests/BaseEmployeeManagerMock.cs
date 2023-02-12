using AutoMapper;
using Moq;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;
namespace WorkSchedule.Tests.EmployeeManagerTests
{
    public abstract class BaseEmployeeManagerMock
    {
        protected readonly Mock<IWorkScheduleRepository<Employee, int>> _empRepositoryMock;
        protected readonly Mock<IMapper> _mapperMock;
        protected readonly Mock<IWorkObjectService> _woServiceMock;
        protected readonly IEmployeeManager _employeeManager;

        protected BaseEmployeeManagerMock()
        {
            _empRepositoryMock = new Mock<IWorkScheduleRepository<Employee, int>>();
            _mapperMock = new Mock<IMapper>();
            _woServiceMock = new Mock<IWorkObjectService>();
            _employeeManager = new EmployeeManager(_empRepositoryMock.Object, _mapperMock.Object, _woServiceMock.Object);
        }
    }
}