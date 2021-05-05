using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("Resolutions")]
    public class Resolution
    {
        [Key]
        public int ResolutionId { get; set; }
        public string Comment { get; set; }
        public virtual Category Category { get; set; }

    }
}
