using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.DTOs.BugalterDtos;
using Application.DTOs.CompanyDtos;
using Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Domain.Entities;
using FluentValidation;
using Infastructure.Interfaces;
using Infastructure.Repositories;
using System.Net;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Application.Services
{
    public class CompanyService(IUnitOfWork ofWork,
                                IValidator<Company> validatorService) : ICompanyService
    {
        private readonly IUnitOfWork _ofWork = ofWork;
        private readonly IValidator<Company> _validatorService = validatorService;

        public async Task CreateAsync(AddCompanyDto dto)
        {
            var result = await _validatorService.ValidateAsync(dto);
            if(!result.IsValid)
                throw new ValidationException(result.GetErrorMessages());
            await _ofWork.Company.CreateAsync((Company)dto);
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            var companies = await _ofWork.Company.GetAllAsync();

            return companies.Select(item => (CompanyDto)item).ToList();
        }

        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            var company = await _ofWork.Company.GetByIdAsync(id);
            if (company is null)
                throw new StatusCodeExeption(HttpStatusCode.NotFound, "Company topilmadi");

            return company;
        }
    }
}