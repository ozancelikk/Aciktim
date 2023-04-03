using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LoginActivitiesManager:ILoginActivitiesService
    {

        private readonly ILoginActivitiesDal _loginActivitiesDal;
        public LoginActivitiesManager(ILoginActivitiesDal loginActivitiesDal)
        {
            _loginActivitiesDal = loginActivitiesDal;

        }
        public IResult Add(LoginActivities loginActivities)
        {
            _loginActivitiesDal.Add(loginActivities);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        public IResult Delete(LoginActivities loginActivities)
        {
            var result = _loginActivitiesDal.Delete(loginActivities);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        public IDataResult<LoginActivities> Get()
        {
            return new SuccessDataResult<LoginActivities>(_loginActivitiesDal.Get(), Messages.Successful);
        }
        public IDataResult<List<LoginActivities>> GetAll()
        {
            var result = _loginActivitiesDal.GetAll();
            return new SuccessDataResult<List<LoginActivities>>(result, $"{result.Count} Adet Aktivite");
        }
        public IDataResult<LoginActivities> GetById(string id)
        {
            return new SuccessDataResult<LoginActivities>(_loginActivitiesDal.Get(l => l.Id == id), Messages.Successful);
        }
    }
}
