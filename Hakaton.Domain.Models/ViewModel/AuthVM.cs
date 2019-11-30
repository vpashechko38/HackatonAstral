using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Domain.Models
{
    public class AuthVM
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class RegistrationVM
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
