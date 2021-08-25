using DBAPIForXamrin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAPIForXamrin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NorthwindController : ControllerBase
    {
       

        private readonly ILogger<NorthwindController> _logger;

        public NorthwindController(ILogger<NorthwindController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {

                var context = new NorthwindContext();
                var EmployeeFirstName = context.Employees.Find(1).FirstName;

                return new List<string>() { EmployeeFirstName };
            }
            catch(Exception e)
            {
                return new List<string>() { "Unable to get any data from database: " + e.Message};
            }

        }
    }
}
