using System;
using System.Linq;
using Unifeso.Db.RavenDbSample.Extensions;
using Unifeso.Db.RavenDbSample.Infrastructure;

namespace Unifeso.Db.RavenDbSample
{
    public static class Program
    {
        static void Main(string[] args)
        {
            using var context = new RavenDbContext();
            
            // Create person
            context.CreatePerson();
            
            // Read person
            var people = context.ReadPeople();
            people.Print();
            
            // Update person
            var person = people.First();
            context.Update(person);
            people = context.ReadPeople();
            people.Print();

            // Delete person
            context.DeleteList(people);
            people = context.ReadPeople();
            people.Print();

            Console.ReadKey();
        }
    }
}
