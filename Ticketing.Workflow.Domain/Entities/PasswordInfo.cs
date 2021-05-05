using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("PasswordInfos")]
    public class PasswordInfo
    {
        [Key]
        public int PassowrdInfoId { get; set; }
        public string password { get; set; }
        public virtual UserInfo user { get; set; }
    }
}
