using Log_Implementataions.Contracts;
using Log_Implementataions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Log_Implementataions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerServices _loggerServices;
    private      ContosoPetsContext db = new ContosoPetsContext();
        public HomeController(ILoggerServices loggerServices)
        {
            _loggerServices = loggerServices;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var location = GetControllerAction();
            _loggerServices.LogInfo($"{location}: Attempted Call ");
            var list = db.Products.ToList();
            if (list.Count()>0)
            {
                _loggerServices.LogInfo($"{location}:Successfull");
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var location = GetControllerAction();
            _loggerServices.LogInfo($"{location}: Attempted Call for id {id}");
            var list = db.Products.Find(id);
            if (list !=null)
            {
                _loggerServices.LogInfo($"{location}:Successfully got record with id: {id}");
            }
            else
            {
                _loggerServices.LogWarn($"{location}: Failed to retrieve record with id: {id}");

            }
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private string GetControllerAction()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;
            return $"{controller }-{action}";
        }
    }
}
