using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Whatsdown_Location_Service.Model;

namespace Whatsdown_Location_Service.Logic
{
    public class FoxLogic
    {
        public async Task<Fox> GetFoxImage()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://randomfox.ca/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync("floof/?ref=apilist.fun");

                if (result.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of
                    // WeatherForecast class
                    var content = await result.Content.ReadAsStringAsync();
                    Fox fox = JsonConvert.DeserializeObject<Fox>(content);
                    return fox;
                }


            }
            return null;
        }
    }
}
