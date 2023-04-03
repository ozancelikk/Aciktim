using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserOperationClaimDal : MongoDB_RepositoryBase<UserOperationClaim, MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>>, IUserOperationClaimDal
    {
        public List<UserOperationClaimsEvolved> GetAllClaims()
        {
            List<UserOperationClaim> _userOperationClaims = new List<UserOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<User> _users = new List<User>();
            List<UserOperationClaimsEvolved> _userOperationClaimsEvolved = new List<UserOperationClaimsEvolved>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            using (var users = new MongoDB_Context<User, MongoDB_UserCollection>())
            {
                _users = users.collection.Find<User>(document => true).ToList();
            }

            using (var operationClaims = new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>())
            {
                _userOperationClaims = operationClaims.collection.Find<UserOperationClaim>(document => true).ToList();
            }


            foreach (var userOperationClaim in _userOperationClaims)
            {
                var currentOperationlaim = _operationClaims.Where(o => o.Id == userOperationClaim.OperationClaimId).FirstOrDefault();
                var currentUser = _users.Where(u => u.Id == userOperationClaim.UserId).FirstOrDefault();

                if (currentUser != null && currentOperationlaim != null)
                {
                    UserOperationClaimsEvolved userOperationClaimsEvolved = new UserOperationClaimsEvolved { Id = userOperationClaim.Id, OperationClaim = currentOperationlaim.Name, OperationClaimId = currentOperationlaim.Id, User = currentUser.FirstName, UserId = currentUser.Id };
                    _userOperationClaimsEvolved.Add(userOperationClaimsEvolved);
                }

            }
            return _userOperationClaimsEvolved;
        }
    }

    }

