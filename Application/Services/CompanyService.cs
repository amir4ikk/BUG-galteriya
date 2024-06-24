using Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Domain.Entities;
using Infastructure.Interfaces;
using System.Net;

namespace Application.Services
{
    public class CompanyService(IUnitOfWork ofWork) : ICompanyService
    {
        private readonly IUnitOfWork ofWork = ofWork;

        public async Task<List<Company>> GetAllAsync()
        {
            var list = await ofWork.Company.GetAllAsync();
            if(list == null)
            {
                throw new StatusCodeExeption(HttpStatusCode.NotFound, "Info is null here");
            }
            return list;
        }

        public Task<Company?> GetByIdAsync(int id)
        {
            var comp = ofWork.Company.GetByIdAsync(id);
            if (comp is null)
                throw new StatusCodeExeption(HttpStatusCode.NotFound, "Company not found");
            return comp;
        }
    }
}