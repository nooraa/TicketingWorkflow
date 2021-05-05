﻿using System;
using log4net;

namespace Ticketing.Workflow.Domain
{
    public class EFDataWriter : IEFDataWriter
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string connectionString = null;

        public EFDataWriter()
        {

        }
        public EFDataWriter(string connectionStr)
        {
            connectionString = connectionStr;
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
                if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("ConnectionString is null!");
                int tickedId = -1;
                if (ticket != null)
                {
                    using (var ctx = new TicketingWorkflowDBContext(connectionString))
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
                if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("ConnectionString is null!");
                int userId = -1;
                if (user != null)
                {
                    using (var ctx = new TicketingWorkflowDBContext(connectionString))
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
    }
}