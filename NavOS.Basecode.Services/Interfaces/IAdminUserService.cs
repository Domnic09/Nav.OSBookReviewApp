﻿using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NavOS.Basecode.Resources.Constants.Enums;

namespace NavOS.Basecode.Services.Interfaces
{
    public interface IAdminUserService
    {
        public LoginResult AuthenticateUser(string adminEmail, string password, ref Admin adminUser);
        public void AddUser(AdminViewModel model);
    }
}