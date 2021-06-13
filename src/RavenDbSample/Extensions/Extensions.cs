using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Unifeso.Db.RavenDbSample.Domain;
using Unifeso.Db.RavenDbSample.Infrastructure;

namespace Unifeso.Db.RavenDbSample.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="context"></param>
        public static void CreatePerson(this RavenDbContext context)
        {
            var person = new Person("Name", new DateTime(1987, 6, 20), "11111111111");
            person.AddAddress("RJ", "Teresópolis", "Rua qualquer", "123", "Ap 100");
            var person2 = new Person("Name 2", new DateTime(1987, 6, 20), "11111111111");
            person.AddAddress("RJ", "Rio de Janeiro", "Rua qualquer 2", "200", "Ap 201");
            using var session = context.CreateSession();
            session.Store(person);
            session.Store(person2);
            session.SaveChanges();
        }
        
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="context"></param>
        public static ICollection<Person> ReadPeople(this RavenDbContext context)
        {
            using var session = context.CreateSession();
            return session.Query<Person>().ToList();
        }
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="context"></param>
        /// <param name="person"></param>
        public static void Update(this RavenDbContext context, Person person)
        {
            person.Update("Updated name", new DateTime(2019, 02, 11), "22222222222");
            person.AddAddress("SP", "São Paulo", "Rua qualquer 3", "5", "Ap 505");
            using var session = context.CreateSession();
            session.Store(person, person.Id);
            session.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="context"></param>
        /// <param name="people"></param>
        public static void DeleteList(this RavenDbContext context, ICollection<Person> people)
        {
            using var session = context.CreateSession();
            foreach (var person in people)
            {
                session.Delete(person.Id);
            }
            session.SaveChanges();
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