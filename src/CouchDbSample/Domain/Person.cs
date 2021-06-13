using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CouchDB.Driver.Types;

namespace Unifeso.Db.CouchDbSample.Domain
{
    public class Person : CouchDocument
    {
        public Person(string name, DateTime dateOfBith, string document)
        {
            Name = name;
            DateOfBith = dateOfBith;
            Document = document;
            Addresses = new List<Address>();
        }
        public string Name { get; private set; }
        public DateTime DateOfBith { get; private set; }
        public string Document { get; private set; }
        public ICollection<Address> Addresses { get; }

        public void AddAddress(string state, string city, string street, string number, string complement)
        {
            var address = new Address(state, city, street, number, complement);
            Addresses.Add(address);
        }
        
        public void Update(string name, DateTime dateOfBith, string document)
        {
            Name = name;
            DateOfBith = dateOfBith;
            Document = document;
        }

        public override string ToString()
        {
            var addresses = new StringBuilder();
            foreach (var address in Addresses)
            {
                addresses.Append($"  - {address}");
            }
            return "===========================\n" +
                   $"Name: {Name}\n" +
                   $"DateOfBirth: {DateOfBith:dd/MM/yyyy}\n" +
                   $"Document: {Document}\n" +
                   $"Addresses:\n" +
                   $"{addresses}" +
                   "===========================\n\n";
        }
    }
}