using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController, Route("api/Tenant/{tenantId}/Values")]
    public class ValuesController : ControllerBase
    {
        private readonly ITenantHolder _tenantHolder;

        public ValuesController(ITenantHolder tenantHolder)
        {
            _tenantHolder = tenantHolder;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get() => Ok(_tenantHolder.Tenant);

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) => "value";

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
