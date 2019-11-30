using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hakaton.Domain;
using Hakaton.Domain.Models;
using Hakaton.Domain.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpPost]
        public JsonResult Authenticate([FromBody]AuthVM authVM)
        {
            var token = _auth.Authorize(authVM);

            if (token == Guid.Empty || token == null)
            {
                return new JsonResult("")
                {
                    StatusCode = 403,
                    Value = "Неверный логин или пароль."
                };
            }

            return new JsonResult("")
            {
                StatusCode = 200,
                Value = JsonConvert.SerializeObject(new { token = token })
            };
        }
    }
}