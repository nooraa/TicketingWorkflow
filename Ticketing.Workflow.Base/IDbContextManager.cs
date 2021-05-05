using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
    public interface IDbContextManager
    {
        /// <summary>
        /// Start db connection
        /// </summary>
        void ConnectToDb();
    }
}
