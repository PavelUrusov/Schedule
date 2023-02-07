﻿using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;

public record EmployeeDto
{
    [Required(ErrorMessage = "The FirstName property is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Role FirstName must contain between 2 and 255 characters")]
    public string Firstname { get; init; } = null!;

    [Required(ErrorMessage = "The Surname property is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Role Surname must contain between 2 and 255 characters")]
    public string Surname { get; init; } = null!;

    [StringLength(255, MinimumLength = 2, ErrorMessage = "Role Lastname must contain between 2 and 255 characters")]
    public string? Lastname { get; init; }
}