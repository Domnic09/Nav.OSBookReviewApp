using NavOS.Basecode.Data;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Repositories;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using NavOS.Basecode.Services.Services;
using NavOS.Basecode.BookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NavOS.Basecode.BookApp
{
    // Other services configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configures the other services.
        /// </summary>
        private void ConfigureOtherServices()
        {
            // Framework
            this._services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            this._services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
//<<<<<<< Rebanda
            this._services.AddScoped<IUserService, UserService>();
            this._services.AddScoped<IBookService, BookService>();
            this._services.AddScoped<IReviewService, ReviewService>();
          

            // Repositories
            this._services.AddScoped<IUserRepository, UserRepository>();
            this._services.AddScoped<IBookRepository, BookRepository>();
            this._services.AddScoped<IReviewRepository, ReviewRepository>();
//=======
            this._services.AddScoped<IAdminService, AdminService>();
          

            // Repositories
            this._services.AddScoped<IAdminRepository, AdminRepository>();
//>>>>>>> main

            this._services.AddHttpClient();
        }
    }
}
