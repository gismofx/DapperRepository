using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DapperRepository
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This adds a Singleton service which produces instances of your db connection
        /// This is to be used for repositories
        /// </summary>
        /// <typeparam name="db">The implementation of IDbConnection</typeparam>
        /// <param name="services"></param>
        /// <param name="connectionString">Database connection string</param>
        /// <returns></returns>
        public static IServiceCollection AddDbConnectionInstantiatorForRepositories<db>(this IServiceCollection services, string connectionString) where db : IDbConnection
        {
            services.TryAddSingleton<Func<IDbConnection>>(sp =>
                () => ActivatorUtilities.CreateInstance<db>(sp, connectionString));
            return services;
        }
    }
}
