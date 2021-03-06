﻿using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BlockchainNodeStatuses.Configuration;
using BlockchainNodeStatuses.Domain;
using BlockchainNodeStatuses.GrpcServices;
using Swisschain.Sdk.Server.Common;

namespace BlockchainNodeStatuses
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            base.ConfigureServicesExt(services);

            
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
        }

        protected override void ConfigureContainerExt(ContainerBuilder builder)
        {
            base.ConfigureContainerExt(builder);

            builder.RegisterType<NodeStatusService>()
                .As<INodeStatusService>()
                .SingleInstance();
        }
    }
}
