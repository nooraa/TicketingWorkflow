using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
    public class TicketRequest
    {
        public string Title { get; set; }
        public string email { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
    }
}
