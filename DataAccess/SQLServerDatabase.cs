using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

namespace DataAccess
{
    /// <summary>
    /// Database class for SQL Server.
    /// </summary>
    public class SQLServerDatabase : IDatabase, IDisposable
    {
        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// SQL Server connection variable.
        /// </summary>
        private SqlConnection _sqlConnection;

        /// <summary>
        /// String that contains the version of the instance of SQL Server to which the client is connected.
        /// </summary>
        private string _serverVersion;

        /// <summary>
        /// Limits concurrent access to a resource.
        /// </summary>
        private Semaphore _semaphore;
        #endregion


        //
        // Properties
        //
        #region Properties

        /// <summary>
        /// Gets the string used to open a SQL Server database.
        /// </summary>
        public string ConnectionString
        {
            get { return _sqlConnection.ConnectionString; }
        }

        /// <summary>
        /// Gets the time to wait while trying to establish a connection before terminating the attempt and generating an error.
        /// </summary>
        public int ConnectionTimeout
        {
            get { return _sqlConnection.ConnectionTimeout; }
        }

        /// <summary>
        /// Gets the name of the current database or the database to be used after a connection is opened.
        /// </summary>
        public string Database
        {
            get { return _sqlConnection.Database; }
        }

        /// <summary>
        /// Gets the name of the instance of SQL Server to which to connect.
        /// </summary>
        public string DataSource
        {
            get { return _sqlConnection.DataSource; }
        }

        /// <summary>
        /// Gets the size (in bytes) of network packets used to communicate with an instance of SQL Server.
        /// </summary>
        public int PacketSize
        {
            get { return _sqlConnection.PacketSize; }
        }

        /// <summary>
        /// Gets a string that contains the version of the instance of SQL Server to which the client is connected.
        /// </summary>
        public string ServerVersion
        {
            get { return _serverVersion; }
        }

        /// <summary>
        /// Indicates the state of the System.Data.SqlClient.SqlConnection.
        /// </summary>
        public ConnectionState State
        {
            get { return _sqlConnection.State; }
        }

        /// <summary>
        /// When set to true, enables statistics gathering for the current connection.
        /// </summary>
        public bool StatisticsEnabled
        {
            get { return _sqlConnection.StatisticsEnabled; }
            set { _sqlConnection.StatisticsEnabled = value; }
        }

        /// <summary>
        /// Gets a string that identifies the database client.
        /// </summary>
        public string WorkstationID
        {
            get { return _sqlConnection.WorkstationId; }
        }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <example>
        /// <code>
        /// SqlServerDatabase database = new SqlServerDatabase("Data Source=(server name);Initial Catalog=(database name);Integrated Security=True;Asynchronous Processing=True");
        /// </code>
        /// </example>
        /// <param name="connectionString">Connection string.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public SQLServerDatabase(string connectionString)
        {
            try
            {
                _semaphore = new Semaphore(1, 1);
                _sqlConnection = new SqlConnection(connectionString)
                {
                    FireInfoMessageEventOnUserErrors = true,
                    StatisticsEnabled = true
                };
                Open();
                _serverVersion = _sqlConnection.ServerVersion;
                _sqlConnection.ResetStatistics();
                Close();
            }
            catch { Close(); throw; }
        }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="dataSource">Name or IP address of the server.</param>
        /// <param name="initialCatalog">Name of the database.</param>
        /// <param name="integratedSecurity">Integrated security. Defaults to true.</param>
        /// <param name="asynchronousProcessing">Determines whether asynchronous processes is enabled. Defaults to true.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public SQLServerDatabase(string dataSource, string initialCatalog, bool integratedSecurity = true, bool asynchronousProcessing = true)
        {
            try
            {
                _semaphore = new Semaphore(1, 1);
                _sqlConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security={2};Asynchronous Processing={3}", dataSource, initialCatalog, integratedSecurity.ToString(), asynchronousProcessing.ToString()))
                {
                    FireInfoMessageEventOnUserErrors = true,
                    StatisticsEnabled = true
                };
                Open();
                _serverVersion = _sqlConnection.ServerVersion;
                _sqlConnection.ResetStatistics();
                Close();
            }
            catch { Close(); throw; }
        }
        #endregion


        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// Opens the connection to the SQL Server.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        private void Open()
        {
            if (_sqlConnection != null)
                _sqlConnection.Open();
        }

        /// <summary>
        /// Closes the connection to the SQL Server.
        /// </summary>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        private void Close()
        {
            if (_sqlConnection != null)
                _sqlConnection.Close();
        }

        /// <summary>
        /// Resets the statistics of the connection to zero.
        /// </summary>
        public void ResetStatistics()
        {
            _sqlConnection.ResetStatistics();
        }

        /// <summary>
        /// Returns a name value pair collection of statistics at the point in time the method is called.
        /// </summary>
        /// <returns>Returns the collection as dictionary.</returns>
        public IDictionary RetrieveStatistics()
        {
            return _sqlConnection.RetrieveStatistics();
        }

        /// <summary>
        /// Handles asynchronous data reception.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Data.DuplicateNameException"></exception>
        /// <exception cref="System.Threading.SemaphoreFullException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                if (((Tuple<int, string, SqlCommand>)result.AsyncState).Item1 == int.MinValue && ((Tuple<int, string, SqlCommand>)result.AsyncState).Item2 == string.Empty)
                {
                    if (DataReceived != null)
                        DataReceived(this, new DataReceivedEventArgs(((Tuple<int, string, SqlCommand>)result.AsyncState).Item1, null));
                }
                else
                {
                    using (var command = ((Tuple<int, string, SqlCommand>)result.AsyncState).Item3)
                    {
                        /*
                        //also works fine :D
                        using (var reader = command.EndExecuteReader(result))
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                        using (var dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataTable.TableName = ((Tuple<int, string, SqlCommand>)result.AsyncState).Item2;
                            if (DataReceived != null)
                                DataReceived(this, new DataReceivedEventArgs(((Tuple<int, string, SqlCommand>)result.AsyncState).Item1, dataTable));
                            dataAdapter.Dispose();
                        }*/
                        using (var reader = command.EndExecuteReader(result))
                        {
                            using (var dataTable = new DataTable())
                            {
                                dataTable.Load(reader);
                                dataTable.TableName = ((Tuple<int, string, SqlCommand>)(result.AsyncState)).Item2;
                                if (DataReceived != null)
                                    DataReceived(this, new DataReceivedEventArgs(((Tuple<int, string, SqlCommand>)result.AsyncState).Item1, dataTable));
                            }
                        }
                    }
                }
                Close();
            }
            catch
            {
                Close();
                _semaphore.Release();
                throw;
            }
        }

        /// <summary>
        /// Executes a query statement expecting no return value.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <param name="param">SQL parameter with name and value.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void ExecuteNonQuery(string query, params SqlParameter[] param)
        {
            try
            {
                Open();
                using (var command = new SqlCommand(query, _sqlConnection))
                {
                    foreach (var p in param)
                        command.Parameters.Add(p);
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
            }
            catch { Close(); throw; }
        }

        /// <summary>
        /// Executes a query statement asynchronously expecting no return value.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <param name="param">SQL parameter with name and value.</param>
        /// <exception cref="System.ObjectDisposedException"></exception>
        /// <exception cref="System.Threading.AbandonedMutexException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void BeginExecuteNonQuery(string query, params SqlParameter[] param)
        {
            try
            {
                _semaphore.WaitOne();
                Open();
                using (var command = new SqlCommand(query, _sqlConnection))
                {
                    foreach (var p in param)
                        command.Parameters.Add(p);
                    command.Prepare();
                    command.BeginExecuteNonQuery(new AsyncCallback(HandleCallback), new Tuple<int, string, SqlCommand>(int.MinValue, string.Empty, command));
                }
            }
            catch
            {
                Close();
                _semaphore.Release();
                throw;
            }
        }

        /// <summary>
        /// Executes a statement expecting one return value.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <param name="param">SQL parameter with name and value.</param>
        /// <returns>Returns the single value as an object.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public object ExecuteScalar(string query, params SqlParameter[] param)
        {
            object o = null;
            try
            {
                Open();
                using (var command = new SqlCommand(query, _sqlConnection))
                {
                    foreach (var p in param)
                        command.Parameters.Add(p);
                    command.Prepare();
                    o = command.ExecuteScalar();
                }
            }
            catch { Close(); throw; }
            return o;
        }

        /// <summary>
        /// Executes a query statement asynchronously expecting a set of return value.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="query">SQL query.</param>
        /// <param name="param">SQL parameter with name and value.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Data.DuplicateNameException"></exception>
        public DataTable ExecuteReader(string tableName, string query, params SqlParameter[] param)
        {
            using (DataTable dataTable = new DataTable())
            {
                try
                {
                    Open();
                    using (var command = new SqlCommand(query, _sqlConnection))
                    {
                        foreach (var p in param)
                            command.Parameters.Add(p);
                        command.Prepare();
                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                            dataTable.TableName = tableName;
                        }
                    }
                }
                catch { Close(); throw; }
                return dataTable;
            }
        }

        /// <summary>
        /// Executes a query statement asynchronously expecting a set of return value.
        /// </summary>
        /// <param name="queryID">Query ID for result set identification.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="query">SQL query.</param>
        /// <param name="param">SQL parameter with name and value.</param>
        public void BeginExecuteReader(int queryID, string tableName, string query, params SqlParameter[] param)
        {
            try
            {
                _semaphore.WaitOne();
                Open();
                using (var command = new SqlCommand(query, _sqlConnection))
                {
                    foreach (var p in param)
                        command.Parameters.Add(p);
                    command.Prepare();
                    command.BeginExecuteReader(new AsyncCallback(HandleCallback), new Tuple<int, string, SqlCommand>(queryID, tableName, command));
                }
            }
            catch
            {
                Close();
                _semaphore.Release();
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <remarks>Requires .NET Framework 4.5 above for asynchronous programming.</remarks>
        public async Task<DataTable> CallSPReader(string tableName, string procedureName, params SqlParameter[] parameters)
        {
            using (var dataTable = new DataTable())
            {
                try
                {
                    Open();
                    using (var command = new SqlCommand(procedureName, _sqlConnection) {
                        CommandTimeout = 1000,
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        foreach (SqlParameter sqlp in parameters)
                            command.Parameters.Add(sqlp);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            dataTable.Load(reader);
                            dataTable.TableName = tableName;
                        }
                    }
                }
                catch { Close(); throw; }
                return dataTable;
            }
        }
        #endregion


        //
        // Static Methods
        //
        #region Static Methods
        //
        // TODO: transfer this to another static class?
        //
        /// <summary>
        /// Enumerates the list of connection strings available on the application.
        /// </summary>
        /// <returns>Returns the list as ConnectionStringSettings</returns>
        public static Dictionary<string, string> EnumerateConnectionStrings()
        {
            Dictionary<string, string> result = new Dictionary<string, string>(1);
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
                result.Add(css.Name, css.ConnectionString);
            return result;
        }
        #endregion


        //
        // IDatabase Members
        //
        #region IDatabase Members

        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// SQL engine used by the instance.
        /// </summary>
        /// <returns>Returns the SQL engine as string.</returns>
        public string GetSQLEngine()
        {
            return "SQL Server";
        }
        #endregion

        //
        // Events
        //
        #region Events

        /// <summary>
        /// Triggers when the database handler receives data from the server.
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        #endregion
        #endregion


        //
        // IDisposable Members
        //
        #region IDisposable Members

        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// Indicates whether Dispose() has already been called.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// Safe handle instance.
        /// </summary>
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Flag that indicates that this method has already been called.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                _semaphore.Close();
                _semaphore.Dispose();
                if (_sqlConnection.State != ConnectionState.Closed)
                    Close();
                _sqlConnection.Dispose();
            }

            disposed = true;
        }
        #endregion
        #endregion
    }
}
