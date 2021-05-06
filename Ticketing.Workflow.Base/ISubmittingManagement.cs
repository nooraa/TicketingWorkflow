using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
   public interface ISubmittingManagement
    {
        /// <summary>
        /// user login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>user info</returns>
        UserInfo Login(LoginInfo login);
        /// <summary>
        /// Gets a list all support engineers.
        /// </summary>
        /// <returns>List of UserInfo</returns>
        List<UserInfo> GetAllSupportEngineers();
        /// <summary>
        /// Assigns ticket to user
        /// </summary>
        /// <param name="assignedUserId"></param>
        /// <param name="ticketId"></param>
        Task AssignTicketToUserAsync(int assignedUserId, int ticketId);
    }
}
