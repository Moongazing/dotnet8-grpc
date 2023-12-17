using Grpc.Core;

Channel channel = new Channel("localhost", 5099, ChannelCredentials.Insecure);

try
{
    var client = new PeopleService.PeopleServiceClient(channel);

    Console.WriteLine("First name?");
    var firstName = Console.ReadLine();

    Console.WriteLine("Last name?");
    var lastName = Console.ReadLine();

    var request = new CreatePersonRequest
    {
        FirstName = firstName,
        LastName = lastName
    };

    var response = await client.CreatePersonAsync(request);

    Console.WriteLine($"{response.FirstName} {response.LastName} has been created on the server! (id = {response.Id})");
}
catch (RpcException rpcEx)
{
    Console.WriteLine($"gRPC call failed with status: {rpcEx.Status.StatusCode}");
    Console.WriteLine($"Detail: {rpcEx.Status.Detail}");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
}
finally
{
    if (channel != null)
    {
        await channel.ShutdownAsync();
    }
}

Console.WriteLine("Press enter to close the client.");
Console.ReadLine();
