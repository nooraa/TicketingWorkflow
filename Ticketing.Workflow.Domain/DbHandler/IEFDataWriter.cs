
namespace Ticketing.Workflow.Domain
{
    public interface IEFDataWriter
    {
        /// <summary>
        /// Insert ticket meta data to DB
        /// </summary>
        /// <param name="ticket">Ticket meta data</param>
        /// <returns></returns>
        int InsertTicket(Ticket ticket );

        /// <summary>
        /// Inserts admin user info to DB
        /// </summary>
        /// <param name="user">Admin user info</param>
        /// <returns></returns>
        int InsertUserInfo(UserInfo user);
        /// <summary>
        /// Uptadet the ticket and assigns it to user
        /// </summary>
        /// <param name="assignedUserId"></param>
        /// <param name="ticketId"></param>
        Ticket UptadeTicket(int assignedUserId, int ticketId);

    }
}
