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

        public UserStorage(IUserRepository userRepo, DataContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }

        public bool Add(RegistrationVM userVm)
        {
            try
            {
                var user = new User
                {
                    Login = userVm.Login,
                    Password = userVm.Password,
                    Name = userVm.Name,
                    Email = userVm.Email,
                    Phone = userVm.Phone
                };

                _userRepo.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public User Get(string login, string password)
        {
            var user = _userRepo.Get(login, password);

            return user;
        }

        public User Get(string token)
        {
            var user = _userRepo.Get(token);

            return user;
        }
    }
}
