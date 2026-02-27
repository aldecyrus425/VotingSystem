using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Services;
using MyApp.Domain.Persistence;
using MyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserServices, UserServices>();
            
            service.AddScoped<IPositionRepository, PositionRepository>();
            service.AddScoped<IPositionServices, PositionsServices>();

            service.AddScoped<IElectionRepository, ElectionRepository>();
            service.AddScoped<IElectionServices, ElectionServices>();

            service.AddScoped<ICandidateRepository, CandidateRepository>();
            service.AddScoped<ICandidateServices, CandidateServices>();



            return service;
        }
    }
}
