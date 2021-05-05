using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Domain
{
    public class EFDataReader : IEFDataReader
    {
        public Ticket GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTickets(int userId)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserInfo(int userId)
        {
            throw new NotImplementedException();
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            using(var ctx = new TicketingWorkflowDBContext())
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
