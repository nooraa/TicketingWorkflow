using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
   public interface ITicketingManagement
    {
        List<CategoryModel> GetCategories();
        List<SubCategoryModel> GetSubCategories();
        bool SaveNewTicket(TicketRequest ticketData);
    }
}
