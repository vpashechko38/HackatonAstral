using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakaton.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;
        public ServiceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> GetService(Category category)
        {
            return await _context.Services.Where(s => s.Category == category).ToListAsync();
        }

        public bool Update(Service service)
        {
            var service = _context.Services.Where(s => s.ServiceId == service.)
        }
    }
}
