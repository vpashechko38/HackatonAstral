using Hakaton.Data.Interface;
using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hakaton.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;       
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(u => u.UserId.Equals(id));
        }

        public User Get(string login, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login) && u.Password.Equals(password));
        }
    }
}
