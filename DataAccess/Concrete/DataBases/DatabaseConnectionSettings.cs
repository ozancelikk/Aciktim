using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases
{
    public class DatabaseConnectionSettings
    {
        public string HostName { get; set; }
        public string Database { get; set; }
        public byte[] CompressStandarts { get; set; }
    }
}
