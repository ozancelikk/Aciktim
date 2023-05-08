using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISupportDal : IEntityRepository<Support>
    {
        List<SupportListDto> GetSupportDetails();
        SupportListDto GetSupportDetailsById(string id);
    }
}
