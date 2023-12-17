using Grpc.Core;

Channel channel = new Channel("localhost:7777", ChannelCredentials.Insecure);



try
{
    await channel.ConnectAsync();
    Console.WriteLine("Channel connected with server.");

    var client = new HelloService.HelloServiceClient(channel);
    var response = client.WelcomeAsync(new HelloRequest()
    {
        FirstName = "Tunahan Ali",
        LastName = "Ozturk"
    });

    var result = await response.ResponseAsync;
    Console.WriteLine(result.Message);
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
