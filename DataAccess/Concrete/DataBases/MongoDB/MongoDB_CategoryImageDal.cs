using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_CategoryImageDal : MongoDB_RepositoryBase<CategoryImage, MongoDB_Context<CategoryImage, MongoDB_CategoryImageCollection>>, ICategoryImageDal
    {
       
    }
}
