using Hakaton.Domain.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Data.Repository
{
    public class DetailIntoRepository : IDetailIntoRepository
    {
        private readonly DataContext _context;
        public DetailIntoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<DetailInfoVm> Get(int serviceId)
        {
            var res = await (from u in _context.Users
                      join s in _context.Services on u.UserId equals s.UserId
                      where s.ServiceId == serviceId
                      select new DetailInfoVm
                      {
                          UserName = u.Name,
                          ServiceName = s.Name,
                          ServiceId = s.ServiceId,
                          Address = s.Address,
                          Description = s.Description,
                          Email = u.Email,
                          Price = s.Price
                      }).SingleAsync();
            res.pathPhotos = await _context.PathPhotos.Where(p => p.ServiceId == serviceId).ToListAsync();
            return res;
        }
    }
}
