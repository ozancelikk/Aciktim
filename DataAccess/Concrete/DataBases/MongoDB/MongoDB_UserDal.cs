using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_UserDal : MongoDB_RepositoryBase<User, MongoDB_Context<User, MongoDB_UserCollection>>, IUserDal
    {
        private readonly IMapper _mapper;

        public MongoDB_UserDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UserEvolved> GetAllWithClaims()
        {
            List<UserEvolved> _userEvolveds = new List<UserEvolved>();
            List<User> _users = new List<User>();
            using (var users = new MongoDB_Context<User, MongoDB_UserCollection>())
            {
                users.GetMongoDBCollection();
                _users = users.collection.Find<User>(document => true).ToList();
            }

            foreach (var user in _users)
            {

                UserEvolved userEvolved = new UserEvolved
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    OperationClaims = GetClaims(user),
                    Status = user.Status

                };
                _userEvolveds.Add(userEvolved);

            }

            return _userEvolveds;

        }

        public UserEvolved GetWithClaims(string userId)
        {

            User user = new User();
            using (var users = new MongoDB_Context<User, MongoDB_UserCollection>())
            {
                users.GetMongoDBCollection();
                user = users.collection.Find<User>(document => document.Id == userId).FirstOrDefault();
            }



            UserEvolved userEvolved = new UserEvolved
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                OperationClaims = GetClaims(user),
                Status = user.Status

            };



            return userEvolved;

        }

        public List<OperationClaim> GetClaims(User user)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<UserOperationClaim> _userOperationClaim = new List<UserOperationClaim>();
            List<OperationClaim> _currentUserOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();

                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();

            }

            using (var operationClaims = new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _userOperationClaim = operationClaims.collection.Find<UserOperationClaim>(document => true).ToList();

            }


            var userOperationClaims = _userOperationClaim.Where(u => u.UserId == user.Id).ToList();
            foreach (var userOperationClaim in userOperationClaims)
            {
                _currentUserOperationClaims.Add(_operationClaims.Where(oc => oc.Id == userOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentUserOperationClaims;

        }

        public void DeleteClaims(User user)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.UserId == user.Id);

            }
        }

        public List<UserDetailsDto> GetAllUser()
        {
            List<User> users=new List<User>();
            using (var userContext = new MongoDB_Context<User, MongoDB_UserCollection>())
            {
                userContext.GetMongoDBCollection();
                users=userContext.collection.Find<User>(document=>true).ToList();
                var userDtos = new List<UserDetailsDto>();
                foreach (var  user in users)
                {
                    if (user.Id!=null)
                    {
                        userDtos.Add(new UserDetailsDto
                        {
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Status = user.Status,
                        });
                    }
                }
                return userDtos;
            }
        }

        public UserDto GetUserById(string id)
        {
            using (var userContext = new MongoDB_Context<User,MongoDB_UserCollection>())
            {
                userContext.GetMongoDBCollection();
                var users = userContext.collection.Find<User>(document=>true).ToList();
                var tempt = users.Find(u => u.Id == id);

                var real=_mapper.Map<UserDto>(tempt);
                return real;
            }
        }
    }
}
