using MassTransit;
using Sample.Worker;

public class AScheduledConsumer : IConsumer<AScheduledMessage>
{
    public Task Consume(ConsumeContext<AScheduledMessage> context)
    {
        return Console.Out.WriteLineAsync($"Message received at {DateTime.Now}");
    }
}
