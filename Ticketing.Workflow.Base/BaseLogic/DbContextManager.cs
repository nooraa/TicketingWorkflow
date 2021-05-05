using Ticketing.Workflow.Domain;
namespace Ticketing.Workflow.Base
{
    public class DbContextManager: IDbContextManager
    {
        private TicketingWorkflowDBContext dbContext;
        public DbContextManager()
        {
            ConnectToDb();
        }

        public void ConnectToDb()
        {
            dbContext = new TicketingWorkflowDBContext();
        }
    }
}
