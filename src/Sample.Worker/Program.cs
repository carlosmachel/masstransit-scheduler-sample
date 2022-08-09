using MassTransit;
using Sample.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {       
        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();

            x.AddConsumer<AScheduledConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.UseDelayedMessageScheduler();
                cfg.ConfigureEndpoints(context);                
            });

           
        });

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
