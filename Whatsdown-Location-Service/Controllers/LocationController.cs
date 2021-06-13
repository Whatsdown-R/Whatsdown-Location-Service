using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whatsdown_Location_Service.Logic;
using Whatsdown_Location_Service.Model;

namespace Whatsdown_Location_Service.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        LocationLogic logic;
        RabbitMQProducer mQProducer;
        ILogger logger;
        public LocationController(ILogger<LocationController> logger)
        {
            this.logic = new LocationLogic();
            this.logger = logger;
         /*   this.mQProducer = new RabbitMQProducer("amqp://guest:guest@localhost:5672");*/
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationFromIp(string ip)
        {
          
            IActionResult response;
            try
            {
                this.logger.LogDebug($"Attempting to get location from ip: {1}", ip);
                string result = await logic.GetLocationFromIPAsync(ip);
               /* mQProducer.Publish(fox);*/
                response = Ok(new { response = result });
              
                return response;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception ex)
            {
                return Unauthorized();
            }
            
        }
    }
}
