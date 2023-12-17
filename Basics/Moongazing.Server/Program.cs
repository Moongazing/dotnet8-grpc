using Grpc.Core;

Server server = new Server()
{

    Ports =
    {
        new ServerPort("localhost", 7777, ServerCredentials.Insecure)
    },
    Services =
    {

    }
};

try
{
    server.Start();
    Console.WriteLine("Server started");
    Console.ReadLine();
}
catch (Exception ex)
{

    Console.WriteLine(ex);
}
finally
{
    if (server is not null)
    {
        await server.ShutdownAsync();
    }
}