using Microsoft.AspNetCore.Cors;
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
        private ITicketingManagement tickitingManagement;
        public TicketingManagementController()
        {
            tickitingManagement = new TicketingManagement();
        }
        [HttpGet]
        public List<CategoryModel> GetCategories()
        {
            return tickitingManagement.GetCategories();
        }

        [HttpGet]
        public List<SubCategoryModel> GetSubCategories()
        {
            return tickitingManagement.GetSubCategories();
        }

        [HttpPost]
        public async Task<bool> SaveNewTicketRequest([FromBody] TicketRequest value)
        {
            return await tickitingManagement.SaveNewTicketAsync(value);
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

        // GET api/<TicketingManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
