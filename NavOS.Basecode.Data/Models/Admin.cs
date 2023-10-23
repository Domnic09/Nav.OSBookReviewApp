using System;
using System.Collections.Generic;

namespace NavOS.Basecode.Data.Models
{
    public partial class Admin
    {
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string ContactNo { get; set; }
        public DateTime Dob { get; set; }
    }
}
