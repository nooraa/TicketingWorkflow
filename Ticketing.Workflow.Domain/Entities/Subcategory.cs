using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("Subcategories")]
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int FK_Category { get; set; }
    }
}
