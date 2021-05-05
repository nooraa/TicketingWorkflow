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
        public string Email { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int  SubcategoryId { get; set; }
        public int FK_Category { get; set; }
        public int? FK_AssignedUser { get; set; }

    }
}
