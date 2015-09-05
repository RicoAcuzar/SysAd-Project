using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccess;

namespace BusinessLogic
{
    /// <summary>
    /// Class that contains global variables.
    /// </summary>
    public static class Globals
    {
        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// Database connection variable.
        /// </summary>
        private static SQLServerDatabase _database;
        #endregion


        //
        // Properties
        //
        #region Properties

        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Initializes the members of this instance.
        /// </summary>
        static Globals()
        {
            bool flag = false;
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                try
                {
                    _database = new SQLServerDatabase(css.ConnectionString);
                    flag = true;
                    break;
                }
                catch { }
            }
            if (!flag) throw new ArgumentException("No connection string was valid.");
        }
        #endregion


        //
        // Methods
        //
        #region Methods

        public static async Task Login(string username, string password)
        {
            var table = await _database.CallSPReader("table name", "SampleSP");
            table.WriteXml(@"C:\Users\jeric_000\Desktop\str.xml");
        }
        #endregion
    }
}
