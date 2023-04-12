using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_FavoriteRestaurantCollection:ICollection
    {
        public string CollectionName { get; set; }
        public MongoDB_FavoriteRestaurantCollection()
        {
            CollectionName = "FavoriteRestaurant";
        }
    }
}
