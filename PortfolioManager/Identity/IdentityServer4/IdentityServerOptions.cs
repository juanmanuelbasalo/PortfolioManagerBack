using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.IdentityServer4
{
    public class IdentityServerOptions
    {
        public string ConnectionString { get; set; }
        public string SecretKey { get; set; }
    }
}
