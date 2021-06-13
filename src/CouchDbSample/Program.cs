using System;
using System.Linq;
using System.Threading.Tasks;
using Unifeso.Db.CouchDbSample.Extensions;
using Unifeso.Db.CouchDbSample.Infrastructure;

namespace Unifeso.Db.CouchDbSample
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await using var context = new CouchDbContext();
            // Create person
            await context.CreatePersonAsync();
            
            // Read person
            var people = await context.ReadPeopleAsync();
            people.Print();
            
            // Update person
            var person = people.First();
            await context.UpdateAsync(person);
            people = await context.ReadPeopleAsync();
            people.Print();

            // Delete person
            await context.DeleteListAsync(people);
            people = await context.ReadPeopleAsync();
            people.Print();

            Console.ReadKey();
        }
    }
}
