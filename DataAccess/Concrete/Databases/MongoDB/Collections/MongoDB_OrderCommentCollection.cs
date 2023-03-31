using DataAccess.Concrete.DataBases.MongoDB.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_OrderCommentCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_OrderCommentCollection()
        {
            CollectionName = "OrderComments";
        }
    }
}
