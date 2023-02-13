using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWorkObjectService _woService;

    public EmployeeManager(IEmployeeRepository repository, IMapper mapper,
        IWorkObjectService woService)
    {
        _repository = repository;
        _mapper = mapper;
        _woService = woService;
    }

    public async Task<ResponseBase> AddEmployeeAsync(RequestAddEmployeeDto dto, int userId)
    {
        var result = await _woService.FindWorkObjectAsync(dto.WorkObject, userId);
        if (result.IsUnsuccessful)
            return result;

        var employee = new Employee
        {
            Firstname = dto.Firstname,
            Surname = dto.Surname,
            Lastname = dto.Lastname,
            WorkObjectId = dto.WorkObject.WorkObjectId
        };
        await _repository.InsertAsync(employee);

        return new ResponseBase();
    }

    public async Task<ResponseBase> AddEmployeeListAsync(RequestAddListEmployeeDto dto, int userId)
    {
        var result = await _woService.FindWorkObjectAsync(dto.WorkObject, userId);
        if (result.IsUnsuccessful)
            return result;

        var empList = dto.Employees.Select(e =>
            new Employee
            {
                Firstname = e.Firstname,
                Surname = e.Surname,
                Lastname = e.Lastname,
                WorkObjectId = dto.WorkObject.WorkObjectId
            });
        await _repository.InsertRangeAsync(empList);

        return new ResponseBase();
    }


    public async Task<ResponseBase> RemoveEmployeeAsync(RequestRemoveEmployeeDto dto, int userId)
    {
        var employee = await FindEmployeeAsync(dto.Id, userId);
        if (employee is null)
            return new ResponseBase("The employee not found", HttpStatusCode.BadRequest);

        await _repository.DeleteAsync(employee);

        return new ResponseBase();
    }

    public async Task<ResponseBase> RemoveListEmployeeAsync(RequestRemoveListEmployeeDto dto, int userId)
    {
        var employeeIds = dto.Employees.Select(x => x.Id).ToList();
        var employees = await FindRangeEmployeeAsync(employeeIds, userId);

        if (employees.Count != employeeIds.Count)
            return new ResponseBase
            {
                ErrorMessage = "The list contains non-existent employees", HttpStatusCode = HttpStatusCode.BadRequest
            };

        await _repository.DeleteRangeAsync(employees);

        return new ResponseBase();
    }

    public async Task<ResponseBase> FindEmployeeAsync(RequestGetEmployeeDto dto, int userId)
    {
        var employee = await FindEmployeeAsync(dto.EmployeeId, userId);

        return employee is null
            ? new ResponseBase("Employee not found", HttpStatusCode.BadRequest)
            : _mapper.Map<Employee, ResponseGetEmployeeDto>(employee);
    }

    public async Task<ResponseBase> GetListEmployeeAsync(RequestGetWorkObjectDto dto, int userId)
    {
        var result = await _woService.FindWorkObjectAsync(dto, userId);
        if (result.IsUnsuccessful)
            return result;

        var emps = await _repository.FindRangeEmployeeByWorkObjectId(dto.WorkObjectId);

        return emps.Count is 0
            ? new ResponseGetListEmployeeDto { Employees = null, WorkObjectId = dto.WorkObjectId }
            : _mapper.Map<IEnumerable<Employee>, ResponseGetListEmployeeDto>(emps);
    }

    protected async Task<Employee?> FindEmployeeAsync(int id, int userId)
    {
        return await _repository.SingleOrDefaultAsync(e => e!.Id == id && e.WorkObject.UserId == userId);
    }

    protected async Task<List<Employee>> FindRangeEmployeeAsync(IEnumerable<int> ids, int userId)
    {
        return await _repository
            .AsQueryable()
            .Where(emp => ids.Contains(emp.Id) && emp.WorkObject.UserId == userId)
            .ToListAsync();
    }
}