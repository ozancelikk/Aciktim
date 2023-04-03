using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ForgottenPassword
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string PrivateKey { get; set; }
    }
}
