using Grpc.Core;


new ServerDbContext().Database.EnsureCreated();

Server server = new Server()
{

    Ports =
    {
        new ServerPort("localhost", 5099, ServerCredentials.Insecure)
    },
    Services =
    {
       PeopleService.BindService(new  PeopleServiceImp())
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