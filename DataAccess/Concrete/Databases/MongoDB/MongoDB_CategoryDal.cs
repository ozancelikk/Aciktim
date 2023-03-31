using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_CategoryDal:MongoDB_RepositoryBase<Category, MongoDB_Context<Category, MongoDB_CategoryCollection>>,ICategoryDal
    {
    }
}
