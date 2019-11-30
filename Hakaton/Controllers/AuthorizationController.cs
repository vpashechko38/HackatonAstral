using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hakaton.Domain;
using Hakaton.Domain.Models;
using Hakaton.Domain.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IUserStorage _userStorage;
        private readonly IAuthorizationLogic _auth;

        public AuthorizationController(IUserStorage userStorage, IAuthorizationLogic auth)
        {
            _userStorage = userStorage;
            _auth = auth;
        }

        [HttpPost("Registration")]
        public bool Registration([FromBody]RegistrationVM registrationVM)
        {
            return _userStorage.Add(registrationVM);
        }

        [HttpGet]
        public Guid Authenticate([FromBody]AuthVM authVM)
        {
            return _auth.Authorize(authVM);
        }
    }
}