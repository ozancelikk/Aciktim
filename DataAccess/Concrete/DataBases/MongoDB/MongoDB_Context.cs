using Core.DataAccess.Databases.MongoDB;
using Core.Entities;
using Core.Entities.Abstract;
using Core.Utilities.IoC;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Threading;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_Context<TEntity, PredefinedCollection> : IDisposable, IMongoDB_Context<TEntity>
       where PredefinedCollection : class, ICollection, new()
       where TEntity : class, IEntity, new()
    {
        public MongoClient client { get; set; }
        public IMongoDatabase database { get; set; }
        public IMongoCollection<TEntity> collection { get; set; }
        private PredefinedCollection predefinedCollection = new PredefinedCollection();

        public MongoDB_Context()
        {
            GetMongoDBCollection();
        }
        public IMongoCollection<TEntity> GetMongoDBCollection()
        {
        tryAgain:
            try
            {
                var database_ConnectionHelper = ServiceTool.Host.Services.GetService<IDatabase_ConnectionHelper>();
                var result = database_ConnectionHelper.CheckDatabaseConnection();
                if (result.Success)
                {
                    client = new MongoClient(result.Data.HostName);
                    database = client.GetDatabase(result.Data.Database);
                    collection = database.GetCollection<TEntity>(predefinedCollection.CollectionName);
                    return collection;
                }
                return null;
            }
            catch (System.Exception)
            {

                Thread.Sleep(15000);
                goto tryAgain;

            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
