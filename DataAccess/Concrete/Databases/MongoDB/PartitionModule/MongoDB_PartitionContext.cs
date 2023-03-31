using Core.Utilities.IoC;
using DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataAccess.Concrete.DataBases.MongoDB.PartitionModule
{
    public class MongoDB_PartitionContext : IDisposable
    {
        private readonly IMongoDatabase _database;
        public MongoDB_PartitionContext(string dbName)
        {
        tryAgain:
            try
            {
                var database_ConnectionHelper = ServiceTool.Host.Services.GetService<IDatabase_ConnectionHelper>();
                var result = database_ConnectionHelper.CheckDatabaseConnection();
                if (result.Success)
                {
                    var client = new MongoClient(result.Data.HostName);
                    _database = client.GetDatabase($"{dbName}-{result.Data.Database}");
                }

            }
            catch (Exception)
            {

                Thread.Sleep(15000);
                goto tryAgain;
            }
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
        {
            return _database.GetCollection<TEntity>(collectionName.Trim());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
