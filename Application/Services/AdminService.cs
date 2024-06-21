using Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using Infastructure.Interfaces;
using System.Net;

namespace Application.Services;

public class AdminService(IUnitOfWork work,
                          IValidator<User> validator) : IAdminService
{
    private readonly IUnitOfWork _work = work;
    private readonly IValidator<User> _validator = validator;

    public async Task ChangeUserRoleAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (user.Roles == Role.SuperAdmin)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "XARRAKIRI");
        
        user.Roles = user.Roles == Role.Admin ? Role.User : Role.Admin;

        await _work.User.UpdateAsync(user);
    }

    public async Task CreateCompanyAsync(string Company, string Creator)
    {
        var comp = new Company()
        {
            Name = Company,
            CreatedAt = DateTime.Now,
            Creator_Name = Creator,
            Employees_Count = 0
        };
        await _work.Company.CreateAsync(comp);
    }

    public async Task DeleteCompanyAsync(int id)
    {
        var comp = await _work.Company.GetByIdAsync(id);
        if (comp is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Comp is not found");
        await _work.Company.DeleteAsync(comp);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        await _work.User.DeleteAsync(user);
    }   

    public async Task<List<User>> GetAllAdminAsync()
        => (await _work.User.GetAllAsync())
            .Where(p =>  p.Roles == Role.Admin)
            .ToList();

    public async Task<List<Company>> GetAllCompanies()
    {
        return await _work.Company.GetAllAsync();
    }
}