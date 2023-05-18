using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_MailConsumerPasswordKeyDal:MongoDB_RepositoryBase<MailConsumerPasswordKey, MongoDB_Context<MailConsumerPasswordKey, MongoDB_MailConsumerPasswordKeyCollection>>,IMailConsumerPasswordKeyDal
    {

    }
}
