using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}
