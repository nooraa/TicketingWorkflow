using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
   public interface ITicketingManagement
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>List of CategoryModel</returns>
        List<CategoryModel> GetCategories();
        /// <summary>
        /// Gets alla Subcatgories
        /// </summary>
        /// <returns>List of CategoryModel</returns>
        List<SubCategoryModel> GetSubCategories();
        /// <summary>
        /// Saves new ticket request
        /// </summary>
        /// <param name="ticketData">Ticket meta data</param>
        /// <returns>ture/false</returns>
        Task<bool> SaveNewTicketAsync(TicketRequest ticketData);
        /// <summary>
        /// Gets all unassigned tickets
        /// </summary>
        /// <returns>List of UnassignedTicket</returns>
        List<UnassignedTicket> GetUnassignedTickets();
    }
}
