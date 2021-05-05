using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Workflow.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticketing.Workflow.WebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketingManagementController : ControllerBase
    {
        private IDbContextManager dbCtx;
        private ITicketingManagement tickitingManagement;
        public TicketingManagementController()
        {
            dbCtx = new DbContextManager();
            dbCtx.ConnectToDb();
            tickitingManagement = new TicketingManagement();
        }
        // GET: api/<TicketingManagementController>
        [HttpGet]
        public List<CategoryModel> GetCategories()
        {
            return tickitingManagement.GetCategories();
        }

        // GET: api/<TicketingManagementController>
        [HttpGet]
        public List<SubCategoryModel> GetSubCategories()
        {
            return tickitingManagement.GetSubCategories();
        }

        // GET api/<TicketingManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TicketingManagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TicketingManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketingManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
