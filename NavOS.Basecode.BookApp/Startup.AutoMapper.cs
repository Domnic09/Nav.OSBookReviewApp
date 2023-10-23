using AutoMapper;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.ServiceModels;
using Microsoft.Extensions.DependencyInjection;

namespace NavOS.Basecode.BookApp
{
    // AutoMapper configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configure auto mapper
        /// </summary>
        private void ConfigureAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            this._services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());
        }

        private class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration()
            {
                CreateMap<AdminViewModel, Admin>();
            }
        }
    }
}
