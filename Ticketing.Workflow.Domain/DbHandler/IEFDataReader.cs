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
        /// Returns a list all support engineers.
        /// </summary>
        /// <returns></returns>
        List<UserInfo> GetAllSupportEngineers();
     
        /// <summary>
        /// Returns a list of Unassigned tickets.
        /// </summary>
        /// <returns></returns>
        List<Ticket> GetUnassignedTickets();
        /// <summary>
        /// User loging
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Loged in User info</returns>
        UserInfo Login(string username, string password);
        /// <summary>
        /// Gets a ticket by ticket ID
        /// </summary>
        /// <param name="id">Ticket ID</param>
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
