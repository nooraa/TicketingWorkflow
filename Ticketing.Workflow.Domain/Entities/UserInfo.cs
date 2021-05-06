using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Workflow.Domain
{
    [Table("UserInfos")]
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public int FK_UserType { get; set; }
    }
}
