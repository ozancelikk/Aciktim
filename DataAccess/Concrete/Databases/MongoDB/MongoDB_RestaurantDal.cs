using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_RestaurantDal:MongoDB_RepositoryBase<Restaurant,MongoDB_Context<Restaurant,MongoDB_RestaurantCollection>>,IRestaurantDal
    {
    }
}
