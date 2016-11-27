using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chosense.Graph.Client
{
    public static class Authentication
    {

        /// <summary>
        /// Returns an authentication context for the given tenant. In multi-tenant applications, the <paramref name="tenantId"/> parameter
        /// can be set to <c>common</c>. It can also be set to the tenant ID guid or the domain used by the tenant, for instance <c>[tenant].onmicrosoft.com</c> or <c>company.com</c>.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static AuthenticationContext CreateContext(string tenantId)
        {
            if(string.IsNullOrEmpty(tenantId)) throw new ArgumentNullException(nameof(tenantId));

            var authority = string.Format("{0}/{1}", Constants.AuthorizationUri, tenantId);
            return new AuthenticationContext(authority);
        }
    }
}
