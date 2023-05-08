using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class RestaurantAccessToken
    {
        public string RestaurantId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Status { get; set; }
    }
}
