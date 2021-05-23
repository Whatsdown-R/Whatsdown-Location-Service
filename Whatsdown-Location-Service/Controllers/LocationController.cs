using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       
        public LocationController()
        {
            this.logic = new LocationLogic();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationFromIp(string ip)
        {
           
            IActionResult response;
            try
            {
                IpLocation fox = await logic.GetLocationFromIPAsync(ip);
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
