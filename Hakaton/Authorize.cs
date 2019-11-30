using Hakaton.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hakaton.App
{
    public class Authorize : Attribute, IAuthorizationFilter
    {
        private readonly IAuthorizationLogic _auth;

        public Authorize(IAuthorizationLogic auth)
        {
            _auth = auth;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_auth.ValidToken(context.HttpContext.Request.Headers["Authorization"]))
            {
                context.Result = new JsonResult("")
                {
                    StatusCode = 401,
                    Value = "Требуется авторизация"
                };
            }
        }
    }
}
