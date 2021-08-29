using HomiePages.Application.Common.Interfaces;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Infrastructure.Identity;
using HomiePages.Infrastructure.Persistence;
using HomiePages.Infrastructure.Repository;
using HomiePages.Infrastructure.Services;
using HomiePages.Infrastructure.Services.EntityServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HomiePages.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("HomiePagesDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IEquityService, EquityService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            services.AddScoped<INotesService, NotesService>();
            services.AddScoped<INoteItemService, NoteItemService>();


            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<IDomainEventService, DomainEventService>();

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(options =>
                {
                    if (!configuration.GetValue<bool>("DevelopmentMode"))
                    {
                        options.IssuerUri = "https://app.homeypages.com";
                    }
                })
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();


            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
    }
}