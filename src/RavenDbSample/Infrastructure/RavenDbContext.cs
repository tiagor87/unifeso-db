using System;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Unifeso.Db.RavenDbSample.Infrastructure
{
    public class RavenDbContext : IDisposable
    {
        private readonly IDocumentStore _store;

        public RavenDbContext()
        {
            _store = new DocumentStore
            {
                Urls = new[]
                {
                    "http://localhost:8080"
                },
                Database = "RavenDbSample"
            }.Initialize();
        }

        public IDocumentSession CreateSession() => _store.OpenSession();
        
        public void Dispose()
        {
            _store.Dispose();
        }
    }
}