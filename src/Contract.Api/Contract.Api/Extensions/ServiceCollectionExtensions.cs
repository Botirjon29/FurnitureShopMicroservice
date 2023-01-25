﻿using Contract.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDbContext(this IServiceCollection collection, ConfigurationManager configuration)
        {
            collection.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("localhost"));

            });
        }
    }
}
