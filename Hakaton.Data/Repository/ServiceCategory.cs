using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hakaton.Data.Repository
{
    class ServiceCategory
    {
        private readonly DataContext _context;
        public ServiceCategory(DataContext context)
        {
            _context = context;
        }
        public async Task<Service> GetService(Category category)
        {
            //return await _context.
        }
    }
}
