using Core.Utilities.IoC;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers
{
    public class MongoDB_ConnectionHelper : IDatabase_ConnectionHelper
    {
        private readonly IConfiguration configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        private readonly CompressionSetting databaseConnectionSettings;
        private readonly EPSResultant epsResultant;
        private readonly DeduplicationStandarts deduplicationStandarts;
        private readonly string Statistics;
        public MongoDB_ConnectionHelper()
        {
            databaseConnectionSettings = configuration.GetSection(nameof(CompressionSetting)).Get<CompressionSetting>();
            epsResultant = configuration.GetSection(nameof(EPSResultant)).Get<EPSResultant>();
            deduplicationStandarts = configuration.GetSection(nameof(DeduplicationStandarts)).Get<DeduplicationStandarts>();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            Statistics = encoding.GetString(deduplicationStandarts.Statics);
        }

        public IDataResult<DatabaseConnectionSettings> CheckDatabaseConnection()
        {
            var result = HashingHelper.VerifyPasswordHash(Statistics, epsResultant.Stability, databaseConnectionSettings.CompressStandarts);

            if (result)
            {
             
                return new SuccessDataResult<DatabaseConnectionSettings>(new DatabaseConnectionSettings { HostName = $"mongodb://" + Environment.GetEnvironmentVariable("DATABASE_HOSTNAME"), Database = databaseConnectionSettings.Database });
            }

            return new ErrorDataResult<DatabaseConnectionSettings>();
        }
    }
}
