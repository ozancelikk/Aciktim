using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserDal : MongoDB_RepositoryBase<User, MongoDB_Context<User, MongoDB_UserCollection>> , IUserDal
    {
    }
}
