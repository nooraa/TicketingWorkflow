using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}
        public string CategoryName { get; set; }
    }
}
