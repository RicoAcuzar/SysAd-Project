using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace DataAccess
{
    /// <summary>
    /// Delegate for DataReceived event.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="queryID">Query ID for result set identification.</param>
    /// <param name="tableName">Name of the table.</param>
    /// <param name="dataTable">Data.</param>
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

    /// <summary>
    /// Argument type for DataReceived event.
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// Query ID for result set identification.
        /// </summary>
        private int _queryID;

        /// <summary>
        /// Data.
        /// </summary>
        private DataTable _dataTable;
        #endregion


        //
        // Properties
        //
        #region Properties

        /// <summary>
        /// Gets or sets the query ID.
        /// </summary>
        public int QueryID
        {
            get { return _queryID; }
            set { _queryID = value; }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="queryID">Query ID for result set identification.</param>
        /// <param name="dataTable">Data.</param>
        public DataReceivedEventArgs(int queryID, DataTable dataTable)
            : base()
        {
            _queryID = queryID;
            _dataTable = dataTable;
        }
        #endregion
    }
}
