using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.DBEntities
{
    public class LoginActivities:IEntity
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string DateTime { get; set; }
        public string Type { get; set; }
    }
}
