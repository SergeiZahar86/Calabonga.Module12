﻿using Calabonga.Contracts;
using Calabonga.Microservices.Core.Exceptions;
using Calabonga.Module12.Web.MassTransit;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Module12.Web.AppStart.ConfigureServices
{
    public class ConfigureServicesMassTransit
    {
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var massTransitSection = configuration.GetSection("MassTransit");
            var url = massTransitSection.GetValue<string>("Url");
            var host = massTransitSection.GetValue<string>("Host");
            var userName = massTransitSection.GetValue<string>("UserName");
            var password = massTransitSection.GetValue<string>("Password");
            if (massTransitSection == null || url == null || host == null)
            {
                throw new MicroserviceArgumentNullException("Section 'mass-transit' configuration settings are not found in appSettings.json");
            }

            services.AddMassTransit(x =>
            {
                x.SetSnakeCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host($"rabbitmq://{url}/{host}", configurator =>
                    {
                        configurator.Username(userName);
                        configurator.Password(password);
                    });

                    cfg.ClearMessageDeserializers();
                    cfg.UseRawJsonSerializer();
                    cfg.UseHealthCheck(context);
                    cfg.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);

                    // регистрация класса подписчика
                    cfg.ReceiveEndpoint(Constants.NotificationQueueNameWarehouse, e =>
                    {
                        e.Consumer<ApplicationUserCreatedConsumer>();
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }

}
