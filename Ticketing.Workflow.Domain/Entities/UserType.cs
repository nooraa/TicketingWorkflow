using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("UserTypes")]
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        public string Type { get; set; }

    }
}
