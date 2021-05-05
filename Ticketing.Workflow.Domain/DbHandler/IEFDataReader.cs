using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Domain
{
   public interface IEFDataReader
    {
        /// <summary>
        /// Gets a ticket by ticket ID
        /// </summary>
        /// <param name="id">Ticket ID</param>
        /// <returns></returns>
        Ticket GetTicket(int id);
        /// <summary>
        /// Gets All tickets assigned to User
        /// </summary>
        ///<param name="userId">User ID</param>
        /// <returns></returns>
        List<Ticket> GetTickets(int userId);
        /// <summary>
        /// Gets user info by user ID
        /// </summary>
        ///<param name="userId">User ID</param>
        /// <returns></returns>
        UserInfo GetUserInfo(int userId);
        /// <summary>
        /// Gets all SubCategories
        /// </summary>
        /// <returns></returns>
        List<SubCategory> GetSubCategories();
        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <returns></returns>
        List<Category> GetCategories();
    }
}
