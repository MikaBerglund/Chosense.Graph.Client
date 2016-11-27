using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chosense.Graph.Client
{
    public static class AuthenticationContextExtensions
    {

        /// <summary>
        /// Returns
        /// </summary>
        /// <param name="authContext"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static async Task<AuthenticationResult> GetAppOnlyGraphTokenAsync(this AuthenticationContext authContext, string clientId, string clientSecret)
        {
            var cred = new ClientCredential(clientId, clientSecret);
            return await authContext.AcquireTokenAsync(Constants.GraphResourceUri, cred);
        }

    }
}
