using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
