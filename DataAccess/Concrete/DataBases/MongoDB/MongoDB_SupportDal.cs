using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_SupportDal : MongoDB_RepositoryBase<Support,MongoDB_Context<Support,MongoDB_SupportCollection>> , ISupportDal
    {
    }
}
