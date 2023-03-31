using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_OperationClaimDal : MongoDB_RepositoryBase<OperationClaim, MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>>, IOperationClaimDal
    {
    }
}
