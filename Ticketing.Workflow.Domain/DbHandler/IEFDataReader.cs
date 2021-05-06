using System.Collections.Generic;

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
