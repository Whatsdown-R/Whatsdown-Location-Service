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
        public async Task<string> GetLocationFromIPAsync(string ip)
        {


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://httpgetdemolocation.azurewebsites.net/api/HttpGetLocation?code=r5UpRXtsb/dquzjG4Q5NMMfsXDPTepVRrhPaS6Cw4YrJq0WcTW84fw==&location=109.33.192.219")
              ,
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {

                    var body = await response.Content.ReadAsStringAsync();
                    response.Content.ToString();
                    Console.WriteLine(body);
                    return body;
                }
            }
            return null;
        }
    }
}
