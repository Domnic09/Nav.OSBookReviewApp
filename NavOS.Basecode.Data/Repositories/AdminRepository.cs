﻿using Basecode.Data.Repositories;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Data.Repositories
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        public AdminRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Admin> GetAdmins()
        {
            return this.GetDbSet<Admin>();
        }

        public bool AdminExists(string email)
        {
            return this.GetDbSet<Admin>().Any(x => x.AdminEmail == email);
        }

        public void AddAdmin(Admin admin) 
        {
            this.GetDbSet<Admin>().Add(admin);
            UnitOfWork.SaveChanges();
        }
    }
}
