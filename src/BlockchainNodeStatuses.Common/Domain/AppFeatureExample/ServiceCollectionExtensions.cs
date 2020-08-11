﻿using Microsoft.Extensions.DependencyInjection;

namespace BlockchainNodeStatuses.Common.Domain.AppFeatureExample
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppFeatureExample(this IServiceCollection services)
        {
            // TODO: Just an example
            services.AddTransient<AppFeatureExample>();

            return services;
        }
    }
}
