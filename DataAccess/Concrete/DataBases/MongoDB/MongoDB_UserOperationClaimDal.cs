using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserOperationClaimDal : MongoDB_RepositoryBase<UserOperationClaim, MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>>, IUserOperationClaimDal
    {
    }
}
