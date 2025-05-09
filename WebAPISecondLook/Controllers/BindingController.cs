using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISecondLook.Models;

namespace WebAPISecondLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {

        [HttpGet("{id:int}/{name:alpha}")]
        public IActionResult Get1(int id ,string name)   //primitive 
        {
            return Ok();
        }

        //complex object 
        [HttpGet]
        public IActionResult PostEmployee([FromQuery]Employee emp)
        {
            return Ok();
        }
    }
}
