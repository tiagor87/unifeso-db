using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouchDB.Driver.Extensions;
using Unifeso.Db.CouchDbSample.Domain;
using Unifeso.Db.CouchDbSample.Infrastructure;

namespace Unifeso.Db.CouchDbSample.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="context"></param>
        public static async Task CreatePersonAsync(this CouchDbContext context)
        {
            var person = new Person("Name", new DateTime(1987, 6, 20), "11111111111");
            person.AddAddress("RJ", "Teresópolis", "Rua qualquer", "123", "Ap 100");
            await context.Persons.AddAsync(person);
            var person2 = new Person("Name 2", new DateTime(1987, 6, 20), "11111111111");
            person.AddAddress("RJ", "Rio de Janeiro", "Rua qualquer 2", "200", "Ap 201");
            await context.Persons.AddAsync(person);
        }
        
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="context"></param>
        public static async Task<ICollection<Person>> ReadPeopleAsync(this CouchDbContext context)
        {
            return await context.Persons.ToListAsync();
        }
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="context"></param>
        /// <param name="person"></param>
        public static async Task UpdateAsync(this CouchDbContext context, Person person)
        {
            person.Update("Updated name", new DateTime(2019, 02, 11), "22222222222");
            person.AddAddress("SP", "São Paulo", "Rua qualquer 3", "5", "Ap 505");
            await context.Persons.AddOrUpdateAsync(person);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="context"></param>
        /// <param name="people"></param>
        public static async Task DeleteListAsync(this CouchDbContext context, ICollection<Person> people)
        {
            foreach (var person in people)
            {
                await context.Persons.RemoveAsync(person);
            }
        }

        public static void Print(this ICollection<Person> people)
        {
            if (!people.Any())
            {
                Console.WriteLine("No people to print.");
                return;
            }
            
            foreach (var person in people)
            {
                person.Print();
            }
        }

        public static void Print(this Person person)
        {
            Console.Write(person);
        }
    }
}