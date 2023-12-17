using Grpc.Core;
using Moongazing.Server.Data.Models;
using Moongazing.Server.Data;
using static PeopleService;

public class PeopleServiceImp : PeopleServiceBase
{
  
    public override async Task<Person> CreatePerson(CreatePersonRequest request, ServerCallContext context)
    {
       using var _context = new ServerDbContext();
            var dbPerson = new DbPerson
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

             _context.People.Add(dbPerson);
            await _context.SaveChangesAsync();

            return new Person
            {
                Id = dbPerson.Id,
                FirstName = dbPerson.FirstName,
                LastName = dbPerson.LastName
            };
        
  
    }

}