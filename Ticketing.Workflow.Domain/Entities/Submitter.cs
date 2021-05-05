using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("Submetters")]
    public class Submetter
    {
        [Key]
        public int SubmitterId { get; set; }
        public string Email { get; set; }

    }
}
