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
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetFox()
        {
            FoxLogic logic = new FoxLogic();
            IActionResult response;
            Fox fox = await logic.GetFoxImage();
            response = Ok(new { test = fox });
            return response;
        }

    }
}
