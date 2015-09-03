using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    /// <summary>
    /// Database interface.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// SQL engine used by the instance
        /// </summary>
        /// <returns>Returns the SQL engine as string.</returns>
        string GetSQLEngine();

        /// <summary>
        /// Triggers when the database handler receives data from the server.
        /// </summary>
        event DataReceivedEventHandler DataReceived;
    }
}
