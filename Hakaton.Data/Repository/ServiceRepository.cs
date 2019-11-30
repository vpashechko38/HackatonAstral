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

        public async Task<Service> Update(Service service)
        {
            var serviceOld = _context.Services.Where(s => s.ServiceId == service.ServiceId).FirstOrDefault();

            serviceOld = service;

            _context.SaveChanges();

            return service;
        }
        public void Delete(Service service)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }
        public async Task<List<Service>> GetServicesUser(int userId)
        {
            return await _context.Services.Where(i => i.UserId == userId).ToListAsync();
        }
        public async Task<Service> Create(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }
    }
}
