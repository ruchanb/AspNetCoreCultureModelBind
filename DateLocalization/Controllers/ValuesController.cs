using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DateLocalization.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Date1(DateTime date)
        {
            return Ok(date);
        }
        [HttpPost]
        public IActionResult Date2(DateModel model)
        {
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Date3([FromBody]DateModel model)
        {
            return Ok(model);
        }
    }
}
