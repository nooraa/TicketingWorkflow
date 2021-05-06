using System.Data.Entity;
using System.Configuration;
namespace Ticketing.Workflow.Domain
{
    public class TicketingWorkflowDBContext: DbContext
    {
        public TicketingWorkflowDBContext(): base("name=ticketWorkflowDB")
        {
        }

        public TicketingWorkflowDBContext(string connectionStr) 
        {
            if (string.IsNullOrEmpty(connectionStr))
            {
               connectionStr = ConfigurationManager.ConnectionStrings["ticketWorkflowDB"].ConnectionString; 
            }
            this.Database.Connection.ConnectionString = connectionStr;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserTypeInfo> UserTypes { get; set; }
        public DbSet<PasswordInfo> PasswordInfos { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
    }
}
