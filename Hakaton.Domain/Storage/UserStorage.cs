using Hakaton.Data;
using Hakaton.Data.Interface;
using Hakaton.Domain.Models;
using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain.Storage
{
    public class UserStorage : IUserStorage
    {
        private readonly IUserRepository _userRepo;
        private readonly DataContext _context;

        public UserStorage(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Add(RegistrationVM userVm)
        {
            var user = new User
            {
                Login = userVm.Login,
                Password = userVm.Password,
                Name = userVm.Name,
                Email = userVm.Email     
            };

            _userRepo.Add(user);
            _context.SaveChanges();
        }

        public User Get(string login, string password)
        {
            var user = _userRepo.Get(login, password);

            return user;
        }
    }
}
