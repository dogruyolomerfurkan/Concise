using Core.RabbitMQ.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.RabbitMQ;

public static class RabbitMQExtensions
{
    public static void AddMassTransitWithRabbitMQ(this IServiceCollection services)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(Assembly.GetEntryAssembly());
            configure.UsingRabbitMq((context, configurator) =>
            {
                IConfiguration configuration = context.GetService<IConfiguration>()!;
                ServiceSettings serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>()!;
                RabbitMQSettings rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>()!;

                configurator.Host(rabbitMQSettings.Host);
                configurator.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
                configurator.UseMessageRetry(retryConfigurator => { retryConfigurator.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });
    }
}