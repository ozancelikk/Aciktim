using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers
{
    public interface IDatabase_ConnectionHelper
    {
        IDataResult<DatabaseConnectionSettings> CheckDatabaseConnection();
    }
}
