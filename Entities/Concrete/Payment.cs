using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? CredidCardNo { get; set; }
        public string? CardExpireDate { get; set; }
        public string? Cvv { get; set; }
        public string? NameOnTheCard { get; set; }
        
    }
}
