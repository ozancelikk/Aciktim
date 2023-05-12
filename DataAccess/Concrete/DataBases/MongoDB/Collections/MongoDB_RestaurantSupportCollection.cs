using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_RestaurantSupportCollection : ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_RestaurantSupportCollection()
        {
            CollectionName = "RestaurantSupports";
        }
    }
}
