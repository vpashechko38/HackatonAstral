using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hakaton.Data
{
    public class DataSeed
    {
        private readonly DataContext _dataContext;
        public DataSeed(DataContext context)
        {
            _dataContext = context;
        }
        User user = new User
        {
            Email = "vpashechko38@gmail.com",
            Login = "test",
            Name = "test",
            Password = "test",
            UserId = 1
        };

        Service service = new Service
        {
            ServiceId = 1,
            Address = "test",
            Category = Domain.Models.Enum.Category.IT,
            Description = "testtest",
            Name = "Repair",
            UserId = 1
        };

        PathPhoto photo1 = new PathPhoto
        {
            Path = "https://sun1-84.userapi.com/c855224/v855224051/182eeb/TwTJNm6TOzo.jpg",
            ServiceId = 1,
            PhotoId = 1
        };
        public bool AddSeed()
        {
            _dataContext.Add(service);
            _dataContext.Add(photo1);
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return true;
        }

    }
}
