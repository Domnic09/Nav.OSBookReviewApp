﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Services.Interfaces
{
    public interface IEmailChecker
    {
        Task<bool> IsEmailValidAsync(string Email);
    }
}
