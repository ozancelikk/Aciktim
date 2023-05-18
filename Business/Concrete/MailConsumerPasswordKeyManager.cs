using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MailConsumerPasswordKeyManager : IMailConsumerPasswordKeyService
    {
        private readonly IMailConsumerPasswordKeyDal _mailConsumerPasswordKeyDal;

        public MailConsumerPasswordKeyManager(IMailConsumerPasswordKeyDal mailConsumerPasswordKeyDal)
        {
            _mailConsumerPasswordKeyDal = mailConsumerPasswordKeyDal;
        }

        public IResult Add(MailConsumerPasswordKey mailConsumerPasswordKey)
        {
            _mailConsumerPasswordKeyDal.Add(mailConsumerPasswordKey);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(string id)
        {
            var restaurant = GetById(id);
            if (restaurant.Data == null)
            {
                return new ErrorResult("Silme işlemi Başarısız");
            }
            var result = _mailConsumerPasswordKeyDal.Delete(restaurant.Data.Id);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult("silme İşlemi Başarılı");
            }
            return new ErrorResult("Silme işlemi Başarısız");
        }
        public IDataResult<MailConsumerPasswordKey> GetById(string id)
        {
            return new SuccessDataResult<MailConsumerPasswordKey>(_mailConsumerPasswordKeyDal.Get(r => r.Id == id), "başarılı");
        }

        public IDataResult<List<MailConsumerPasswordKey>> Get(string id)
        {
            return new SuccessDataResult<List<MailConsumerPasswordKey>>(_mailConsumerPasswordKeyDal.GetAll(r => r.Id == id), "başarılı");
        }

        public IDataResult<List<MailConsumerPasswordKey>> GetAll()
        {
            return new SuccessDataResult<List<MailConsumerPasswordKey>>(_mailConsumerPasswordKeyDal.GetAll(),"Başarılı");
        }

        public IDataResult<MailConsumerPasswordKey> GetByMail(string mail)
        {
            return new SuccessDataResult<MailConsumerPasswordKey>(_mailConsumerPasswordKeyDal.Get(x => x.Mail == mail), "Başarılı");
        }

        public IResult asd(string key,string mail)
        {
            var x = GetByMail(mail);
            if (x.Data.PrivateKey==key)
            {
                return new SuccessResult("Doğrulama Başarılıdır");
            }
            return new ErrorResult("Doğrulama işlemi başarısızdır");
        }
    }
}
