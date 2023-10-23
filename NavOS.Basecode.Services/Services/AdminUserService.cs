using AutoMapper;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.Manager;
using NavOS.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NavOS.Basecode.Resources.Constants.Enums;

namespace NavOS.Basecode.Services.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public AdminUserService(IAdminRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public LoginResult AuthenticateUser(string adminEmail, string password, ref Admin adminUser)
        {
            adminUser = new Admin();
            var passwordKey = PasswordManager.EncryptPassword(password);

            adminUser = _repository.GetUsers().Where(x => x.AdminEmail == adminEmail &&
                                                     x.Password == passwordKey).FirstOrDefault();

            return adminUser != null ? LoginResult.Success : LoginResult.Failed;
        }
        public void adduser(AdminViewModel model)
        {
            var user = new Admin();
            if (!_repository.UserExists(model.AdminEmail))
            {
                _mapper.Map(model, user);
                user.Password = PasswordManager.EncryptPassword(model.Password);
                _repository.AddAdmin(user);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }


        public void AddUser(AdminViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
