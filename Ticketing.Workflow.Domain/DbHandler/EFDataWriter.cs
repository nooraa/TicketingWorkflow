using System;
using log4net;
using System.Linq;

namespace Ticketing.Workflow.Domain
{
    public class EFDataWriter : IEFDataWriter
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EFDataWriter()
        {

        }

        /// <summary>
        /// Inserts ticket meta data to DB
        /// </summary>
        /// <param name="ticket">Ticket meta data</param>
        /// <returns></returns>
        public int InsertTicket(Ticket ticket)
        {
            try
            {
                int tickedId = -1;
                if (ticket != null)
                {
                    using (var ctx = new TicketingWorkflowDBContext())
                    {
                        ctx.Tickets.Add(ticket);
                        ctx.SaveChanges();
                        tickedId = ticket.TicketId;
                        log.Info($"Successfully saved ticket, id: { ticket.TicketId}");
                    }
                }
                return tickedId;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        /// <summary>
        /// Inserts admin users data to DB
        /// </summary>
        /// <param name="user">Admin user info</param>
        /// <returns></returns>

        public int InsertUserInfo(UserInfo user)
        {
            try
            {
                int userId = -1;
                if (user != null)
                {
                    using (var ctx = new TicketingWorkflowDBContext())
                    {
                        ctx.UserInfos.Add(user);
                        ctx.SaveChanges();
                        userId = user.UserId;
                        log.Info($"Successfully saved user, id: { user.UserId}");
                    }
                }
                return userId;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public Ticket UptadeTicket(int assignedUserId, int ticketId)
        {
            try
            {
                Ticket ticket = null;
                    using (var ctx = new TicketingWorkflowDBContext())
                    {
                    ticket = ctx.Tickets.Where(t => t.TicketId == ticketId).FirstOrDefault();
                    if(ticket != null)
                    {
                        ticket.FK_AssignedUser = assignedUserId;
                        ticket.Status = "Assigned";
                        ctx.SaveChanges();
                        log.Info($"Successfully updated ticked, id: {ticket.TicketId}");
                    }
                }
                return ticket;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
