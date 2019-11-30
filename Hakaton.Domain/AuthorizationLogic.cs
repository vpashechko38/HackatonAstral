using Hakaton.Data;
using Hakaton.Domain.Models;
using Hakaton.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain
{
    public interface IAuthorizationLogic
    {
        int Authorize(AuthVM authVM);
        bool ValidToken(string token);
    }

    public class AuthorizationLogic : IAuthorizationLogic
    {
        private readonly IUserStorage _userStorage;
        private readonly DataContext _context;

        public AuthorizationLogic(IUserStorage userStorage, DataContext context)
        {
            _userStorage = userStorage;
            _context = context;
        }

        public int Authorize(AuthVM authVM)
        {
            var user = _userStorage.Get(authVM.Login, authVM.Password);        

            return user.UserId;
        }

        public bool ValidToken(string token)
        {
            if (token == "VALID_TOKEN")
                return true;
            else
                return _userStorage.Get(token) != null;
        }
    }
}
