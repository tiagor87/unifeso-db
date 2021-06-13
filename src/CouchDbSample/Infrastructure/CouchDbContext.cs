using CouchDB.Driver;
using CouchDB.Driver.Options;
using Unifeso.Db.CouchDbSample.Domain;

namespace Unifeso.Db.CouchDbSample.Infrastructure
{
    public class CouchDbContext : CouchContext
    {
        public CouchDatabase<Person> Persons { get; set; }

        protected override void OnConfiguring(CouchOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseEndpoint("http://localhost:5984")
                .EnsureDatabaseExists()
                .UseBasicAuthentication("admin", "password");
        }
    }
}