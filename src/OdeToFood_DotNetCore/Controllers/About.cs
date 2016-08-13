using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood_DotNetCore.Controllers
{
    //[Route("about")]
    [Route("[controller]")]  //Name of the controller
    //[Route("company/[controller]/[action]")]  //Remove atributes from actions
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+52-8182020346";
        }

        //[Route("country")]
        [Route("[action]")] //Name of the action
        public string Country()
        {
            return "MX";
        }
    }
}
