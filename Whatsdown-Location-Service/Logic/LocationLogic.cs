using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Whatsdown_Location_Service.Model;

namespace Whatsdown_Location_Service.Logic
{
    public class LocationLogic
    {
        ILogger logger;
        public LocationLogic()
        {
          
        }

        //
        public async Task<IpLocation> GetLocationFromIPAsync(string ip)
        {
            var match = Regex.Match(ip, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b");
            if (!match.Success)
            {
                logger.LogWarning($"Attempted to get location from variable that did not have the normal ip regex : {1}", ip);
                throw new ArgumentException("The variable is not an ip adress");
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/ip.json?q=" + ip),
                Headers =
             {
        { "x-rapidapi-key", "af62e88497msh6cf846cb65ee11fp19a3e4jsn459a722086e1" },
        { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
             },
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {

                    var body = await response.Content.ReadAsStringAsync();
                    IpLocation location = JsonConvert.DeserializeObject<IpLocation>(body);
                    logger.LogWarning($"succesfully got location from ip. Location: {1}, ip: {2}", location.country_name, ip);
                    return location;
                }
            }
            return null;
        }
    }
}
