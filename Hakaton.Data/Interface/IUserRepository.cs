﻿using Hakaton.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hakaton.Data.Interface
{
    public interface IUserRepository
    {
        User Get(int id);
        User Get(string login, string password);
        void Add(User user);
    }
}
