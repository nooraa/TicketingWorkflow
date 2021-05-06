using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Domain
{
    public class EFDataReader : IEFDataReader
    {
        public EFDataReader() { }

        /// <summary>
        /// Returns a list of Unassigned tickets.
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetUnassignedTickets()
        {
            List<Ticket> ticketList = new List<Ticket>();
             using (var ctx = new TicketingWorkflowDBContext())
            {
                ticketList = ctx.Tickets.Where(t => t.FK_AssignedUser == null).ToList();
            }
            return ticketList;
        }

        /// <summary>
        /// Gets a list all support engineers.
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetAllSupportEngineers()
        {
            List<UserInfo> users = new List<UserInfo>();
            using (var ctx = new TicketingWorkflowDBContext())
            {
                var supportEngType = ctx.UserTypes.Where(t => t.UserType.Equals("Support Engineer")).FirstOrDefault();
                users = ctx.UserInfos.Where(u => u.FK_UserType == supportEngType.UserTypeId).ToList();
            }
            return users;
        }
        /// <summary>
        /// User loging
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Loged in User info</returns>
        public UserInfo Login(string username, string password)
        {
            UserInfo user;
            PasswordInfo passinfo = null;
            using (var ctx = new TicketingWorkflowDBContext())
            {
                user = ctx.UserInfos.Where(user => user.Username == username).FirstOrDefault();
                if (user != null)
                {
                    passinfo = ctx.PasswordInfos.Where(pass => pass.FK_User == user.UserId).FirstOrDefault();
                }
            }
            return passinfo == null ? null : user;
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            using (var ctx = new TicketingWorkflowDBContext())
            {
                subCategories = ctx.SubCategories.ToList();

            }
            return subCategories;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var ctx = new TicketingWorkflowDBContext())
            {
                categories = ctx.Categories.ToList();

            }
            return categories;
        }
    }
}
