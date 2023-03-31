using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using Entities.Concrete;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_CustomerDal : MongoDB_RepositoryBase<Customer, MongoDB_Context<Customer, MongoDB_CustomerCollection>>, ICustomerDal
    {
    }
}
