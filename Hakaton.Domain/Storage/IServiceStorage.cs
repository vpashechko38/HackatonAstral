﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;

namespace Hakaton.Domain.Storage
{
    public interface IServiceStorage
    {
        Task<List<Service>> GetService(Category category);
        Task<Service> UpdateService(Service service);
        void Delete(Service service);
        Task<List<Service>> GetServicesUser(int userId);
        Task<Service> Create(Service service);
    }
}