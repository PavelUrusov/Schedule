using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;
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

    public async Task<ResponseBase> AddEmployeeAsync(RequestAddEmployeeDto dto, int userId)
    {
        var result = await _woService.GetWorkObjectAsync(dto.WorkObject, userId);
        if (result.IsUnsuccessful)
            return result;

        var employee = new Employee
        {
            Firstname = dto.Firstname,
            Surname = dto.Surname,
            Lastname = dto.Lastname,
            WorkObjectId = dto.WorkObject.WorkObjectId
        };
        await _empRepository.InsertAsync(employee);

        return new ResponseBase();
    }

    public async Task<ResponseBase> AddEmployeeListAsync(RequestAddListEmployeeDto dto, int userId)
    {
        var result = await _woService.GetWorkObjectAsync(dto.WorkObject, userId);
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
        await _empRepository.InsertRangeAsync(empList);

        return new ResponseBase();
    }


    public async Task<ResponseBase> RemoveEmployeeAsync(RequestRemoveEmployeeDto dto, int userId)
    {
        var employee =
            await _empRepository.FirstOrDefaultAsync(emp => emp!.Id == dto.Id && emp.WorkObject.UserId == userId);
        if (employee is null)
            return new ResponseBase("The employee not found", HttpStatusCode.BadRequest);

        await _empRepository.DeleteAsync(employee);

        return new ResponseBase();
    }

    public async Task<ResponseBase> RemoveListEmployeeAsync(RequestRemoveListEmployeeDto dto, int userId)
    {
        var employeeIds = dto.Employees.Select(x => x.Id);
        var emps = await _empRepository
            .CreateQueryable()
            .Where(emp => employeeIds.Contains(emp.Id) && emp.WorkObject.UserId == userId)
            .ToListAsync();

        await _empRepository.DeleteRangeAsync(emps);

        return new ResponseBase();
    }


    //TODO WILL CREATE NORMAL DTOS,REFACTOR DTOS.
    /*public async Task<ResponseBase> GetListEmployeeWithSchedulesAsync(GetEmployeeWithSchedulesDto dto, int userId)
    {
        var result = await _woService.GetWorkObjectAsync(dto, userId);
        if (result.IsUnsuccessful)
            return result;

        var emps = await _empRepository.CreateQueryable()
            .Include(emp => emp.Schedules)
            .Include(emp => emp.Schedules.Select(x => x.WorkSchema))
            .Where(emp => emp.WorkObjectId == dto.WorkObjectId)
            .Select(emp => _mapper.Map<Employee, GetEmployeeDto>(emp))
            .ToListAsync();

        return new GetListEmployeeDto { Employees = emps };
    }*/
}