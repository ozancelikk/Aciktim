using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
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

        public List<UserClaimDetailsDto> GetClaimDetails()
        {
            List<User> user = new List<User>();
            List<UserOperationClaim> _usertOperationClaim = new List<UserOperationClaim>();
            List<UserClaimDetailsDto> dtos = new List<UserClaimDetailsDto>();

            using (var customers = new MongoDB_Context<User, MongoDB_UserCollection>())
            {
                customers.GetMongoDBCollection();
                user = customers.collection.Find<User>(document => true).ToList();
            }
            List<OperationClaim> claims = new List<OperationClaim>();
            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                claims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            List<OperationClaim> _currentUserOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _usertOperationClaim = operationClaims.collection.Find<UserOperationClaim>(document => true).ToList();
            }
            var userOperationClaims = _usertOperationClaim.Where(u => true).ToList();   // restaurantların claimlerini tutuyor


            foreach (var userOperationClaim in userOperationClaims)
            {
                var currentUser = user.Find(x => x.Id == userOperationClaim.UserId);       // current restaurant
                var claimName = claims.Find(x => x.Id == userOperationClaim.OperationClaimId);
                dtos.Add(new UserClaimDetailsDto
                {
                    OperationClaimName = claimName.Name,
                    UserName = currentUser.Email
                });
            }
            return dtos;
        }
    }

    }

