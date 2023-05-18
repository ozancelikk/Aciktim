using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_MailConsumerPasswordKeyCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_MailConsumerPasswordKeyCollection()
        {
            CollectionName = "MailConsumerPasswordKeys";
        }
    }
}
