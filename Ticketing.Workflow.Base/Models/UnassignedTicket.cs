using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
   public class UnassignedTicket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string SubmitterEmail { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
