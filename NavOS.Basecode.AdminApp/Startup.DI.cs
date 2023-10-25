using NavOS.Basecode.Data;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Repositories;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using NavOS.Basecode.Services.Services;
using NavOS.Basecode.AdminApp.Authentication;
using NavOS.Basecode.AdminApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NavOS.Basecode.AdminApp
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
            this._services.AddScoped<TokenProvider>();
            this._services.TryAddSingleton<TokenProviderOptionsFactory>();
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IAdminService, AdminService>();
            this._services.AddScoped<IBookService, BookService>();


            // Repositories
            this._services.AddScoped<IAdminRepository, AdminRepository>();
            this._services.AddScoped<IBookRepository, BookRepository>();

            // Manager Class
            this._services.AddScoped<SignInManager>();

            this._services.AddHttpClient();
        }
    }
}
