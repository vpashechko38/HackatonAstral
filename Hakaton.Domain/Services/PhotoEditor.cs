using Hakaton.Data;
using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Domain.Services
{
    public class PhotoEditor
    {
        private readonly DataContext _dataContext;
        public PhotoEditor(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> AddPhoto(int serviceId, string path)
        {
            var photo = new PathPhoto
            {
                Path = path,
                ServiceId = serviceId
            };

            await _dataContext.AddAsync(photo);
            await _dataContext.SaveChangesAsync();

            return photo.PhotoId;
        }

        public async Task<bool> Delete(int photoId)
        {
            var photo = await _dataContext.PathPhotos.SingleAsync(p=>p.PhotoId==photoId);
            var res = _dataContext.PathPhotos.Remove(photo);
            return true;
        }
    }
}
