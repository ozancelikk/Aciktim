using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_RestaurantOperationClaimCollection : ICollection
    {
        public string CollectionName { get ; set; }

        public MongoDB_RestaurantOperationClaimCollection()
        {
            CollectionName = "RestaurantOperationClaim";
        }
    }
}
