using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BugalterService : IBugalterService
    {
        public Task CreateAsync(AddBugalterDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BugalterDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BugalterDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BugalterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
