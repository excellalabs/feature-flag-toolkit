using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Services
{
    public class FlagrService
    {
        private UserService userService = new UserService();

        public async Task<bool> ShouldDisplayAllContent()
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(new
            {
                flagKey = "AdminContent",
                entityContext = new { IsAdmin = userService.IsUserAdmin().ToString().ToLower() }
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:18000/api/v1/evaluation", data);
            var contents = await response.Content.ReadAsStringAsync();

            var asJobject = JObject.Parse(contents);
            if (asJobject["variantKey"] == null ||
                asJobject["variantKey"].ToString().Equals("AllContent", StringComparison.CurrentCultureIgnoreCase)) {
                return true;
            }

            return false;
        }
    }
}
