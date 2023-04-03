using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILoginActivitiesService
    {
        IDataResult<LoginActivities> GetById(string id);
        IDataResult<List<LoginActivities>> GetAll();
        IResult Add(LoginActivities loginActivities);
        IResult Delete(LoginActivities loginActivities);
        IDataResult<LoginActivities> Get();
    }
}
