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
        private ISubmittingManagement submittingManagement;
        public TicketingManagementController()
        {
            tickitingManagement = new TicketingManagement();
            submittingManagement = new SubmittingManagement();
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
        [HttpGet]
        public List<UserInfo> GetSupportEngineers()
        {
            return submittingManagement.GetAllSupportEngineers();
        }

        [HttpGet]
        public List<UnassignedTicket> GetUnassignedTickets()
        {
            return tickitingManagement.GetUnassignedTickets();
        }

        [HttpPost]
        public async Task<bool> SaveNewTicketRequest([FromBody] TicketRequest value)
        {
            return await tickitingManagement.SaveNewTicketAsync(value);
        }

        [HttpPost]
        public void AssignTicketToUser([FromBody] TicketAssignReq value)
        {
             submittingManagement.AssignTicketToUserAsync(value.AssignedUserId, value.TicketId);
        }
        [HttpPost]
        public UserInfo Login([FromBody] LoginInfo value)
        {
            return submittingManagement.Login(value);
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
