using Hakaton.Domain.Models;
using Hakaton.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain
{
    public interface IAuthorizationLogic
    {
        bool Authorize(AuthVM authVM);
    }

    public class AuthorizationLogic : IAuthorizationLogic
    {
        private IUserStorage _userStorage;

        public AuthorizationLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public bool Authorize(AuthVM authVM)
        {
            var user = _userStorage.Get(authVM.Login, authVM.Password);
            return user != null;
        }
    }
}
