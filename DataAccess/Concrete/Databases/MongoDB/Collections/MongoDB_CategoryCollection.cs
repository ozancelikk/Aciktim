using Core.DataAccess.Databases.MongoDB;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_CategoryCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_CategoryCollection()
        {
            CollectionName = "Categories";
        }
    }
}
