using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chosense.Graph.Client
{
    public static class Graph
    {

        public static GraphServiceClient AppOnlyClient(string tenantId, string clientId, string clientSecret)
        {
            return new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        var authContext = Authentication.CreateContext(tenantId);
                        var token = await authContext.GetAppOnlyGraphTokenAsync(clientId, clientSecret);

                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
                    }
                )
            );
        }




        public static IGraphServiceUsersCollectionRequest FilterByPrincipalName(this IGraphServiceUsersCollectionRequest request, string principalName)
        {
            return request.Filter(string.Format("UserPrincipalName eq '{0}'", principalName));
        }

        public static IUserContactsCollectionRequest FilterByEmail(this IUserContactsCollectionRequest request, string email)
        {
            return request.Filter(string.Format("EmailAddresses/any(x:x/address eq '{0}')", email));
        }

        public static async Task<User> FirstOrDefaultAsync(this IGraphServiceUsersCollectionRequest request)
        {
            User user = null;

            var result = await request.GetAsync();
            user = result.FirstOrDefault();

            return user;
        }

        public static async Task<Contact> FirstOrDefaultAsync(this IUserContactsCollectionRequest request)
        {
            Contact contact = null;

            var result = await request.GetAsync();
            contact = result.FirstOrDefault();

            return contact;
        }

    }
}
