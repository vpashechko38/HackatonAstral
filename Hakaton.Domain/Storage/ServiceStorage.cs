using Hakaton.Data.Repository;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hakaton.Domain.Storage
{
    public class ServiceStorage : IServiceStorage
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceStorage(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<List<Service>> GetService(Category category)
        {
            return await _serviceRepository.GetService(category);
        }
        public async Task<Service> UpdateService(Service service)
        {
            return await _serviceRepository.Update(service);
        }
        public void Delete(Service service)
        {
            _serviceRepository.Delete(service);
        }
    }
}
