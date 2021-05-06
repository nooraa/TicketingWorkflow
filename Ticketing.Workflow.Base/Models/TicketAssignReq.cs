using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
    public class TicketAssignReq
    {
        public int TicketId { get; set; }
        public int AssignedUserId { get; set; }
    }
}
