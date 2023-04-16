using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_MenuImageDal : MongoDB_RepositoryBase<MenuImage,MongoDB_Context<MenuImage,MongoDB_MenuImageCollection>> , IMenuImageDal
    {
    }
}
