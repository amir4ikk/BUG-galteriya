﻿using Domain.Entities;
using Infastructure.Interfaces;

namespace Application.DTOs.BugalterDtos;

public class UserDto()
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public int Salary { get; set; }
    public int Time {  get; set; }
    public double Tax { get; set; }
    
    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FullName = user.FullName,
            Salary = user.Per_Hour * user.Work_Time,
            Tax = user.Per_Hour * user.Work_Time * 0.12,
            Time = user.Work_Time
        };
    }
}