using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_RestaurantImageCollection : ICollection
    {
        public string CollectionName { get; set ; }

        public MongoDB_RestaurantImageCollection()
        {
            CollectionName ="RestaurantImages";
        }
    }
}
