using FeatureFlags.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeatureFlags.Services
{
    public class FeatureFlagModelsService
    {
        public async Task<List<FeatureFlag>> GetFlags()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("http://localhost:18000/api/v1/flags");
            var flagsAsJson = JArray.Parse(response);
            return JsonConvert.DeserializeObject<List<FeatureFlag>>(flagsAsJson.ToString());
        }
    }
}