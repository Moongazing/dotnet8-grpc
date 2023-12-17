using Grpc.Core;

Channel channel = new Channel("localhost:7777", ChannelCredentials.Insecure);



try
{
    await channel.ConnectAsync();
    Console.WriteLine("Channel connected with server.");
    Console.ReadLine();
}
catch (Exception ex)
{

    Console.WriteLine(ex);
}
finally
{
    if (channel is not null)
    {
        await channel.ShutdownAsync();
    }
}
