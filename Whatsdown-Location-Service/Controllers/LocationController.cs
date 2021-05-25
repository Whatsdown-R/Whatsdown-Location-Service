using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       
        public LocationController()
        {
            this.logic = new LocationLogic();
         /*   this.mQProducer = new RabbitMQProducer("amqp://guest:guest@localhost:5672");*/
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationFromIp(string ip)
        {
           
            IActionResult response;
            try
            {
                IpLocation fox = await logic.GetLocationFromIPAsync(ip);
               /* mQProducer.Publish(fox);*/
                response = Ok(new { test = fox });
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
