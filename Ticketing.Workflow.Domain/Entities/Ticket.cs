using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual Submetter submitter { get; set; }
        public virtual UserInfo user { get; set; }
    }
}
