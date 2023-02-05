using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Employee;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObject;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.EmployeeManager;

public class EmployeeManager : IEmployeeManager
{
    private readonly IWorkScheduleRepository<Employee, int> _empRepository;
    private readonly IMapper _mapper;
    private readonly IWorkObjectService _woService;

    public EmployeeManager(IWorkScheduleRepository<Employee, int> empRepository, IMapper mapper,
        IWorkObjectService woService)
    {
        _empRepository = empRepository;
        _mapper = mapper;
        _woService = woService;
    }

    public async Task<ResponseBase> AddEmployeeAsync(AddEmployeeDto dto, int userId)
    {
        var result = await _woService.GetWorkObjectAsync(new WorkObjectIdDto { Id = dto.WorkObjectId }, userId);
        if (result.IsUnsuccessful)
            return result;

        var employee = new Employee
        {
            Firstname = dto.Firstname,
            Surname = dto.Surname,
            Lastname = dto.Lastname,
            WorkObjectId = dto.WorkObjectId
        };
        await _empRepository.InsertAsync(employee);

        return new ResponseBase();
    }

    public async Task<ResponseBase> AddEmployeeListAsync(AddListEmployeeDto dto, int userId)
    {
        var result = await _woService.GetWorkObjectAsync(new WorkObjectIdDto { Id = dto.WorkObjectId }, userId);
        if (result.IsUnsuccessful)
            return result;

        var empList = dto.Dtos.Select(e =>
            new Employee
            {
                Firstname = e.Firstname,
                Surname = e.Surname,
                Lastname = e.Lastname,
                WorkObjectId = dto.WorkObjectId
            });
        await _empRepository.InsertRangeAsync(empList);

        return new ResponseBase();
    }
}