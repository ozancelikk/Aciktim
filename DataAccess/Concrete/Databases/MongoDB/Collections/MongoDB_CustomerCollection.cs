using DataAccess.Concrete.DataBases.MongoDB.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_CustomerCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_CustomerCollection()
        {
            CollectionName = "Customers";
        }
    }
}
