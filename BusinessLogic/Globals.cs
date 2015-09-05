using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        /// <summary>
        /// Holds the account information of the logged-in user.
        /// </summary>
        private static Account _account;

        /// <summary>
        /// Holds the price per kiloWatt-hour.
        /// </summary>
        private static double _kwh;

        /// <summary>
        /// Handles the hardware communication.
        /// </summary>
        private static Microcontroller _microcontroller;
        #endregion


        //
        // Properties
        //
        #region Properties

        /// <summary>
        /// Gets the account of the currently logged-in user.
        /// </summary>
        public static Account Account
        {
            get { return _account; }
        }

        /// <summary>
        /// Gets or sets the price per kiloWatt-hour.
        /// </summary>
        public static double KWH
        {
            get { return _kwh; }
            set { _kwh = value; }
        }
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
            _database = new SQLServerDatabase(@"Gamer-PC\SQLEXPRESS", "HCS");
            _account = null;
            /*bool flag = false;
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
            if (!flag) throw new ArgumentException("No connection string was valid.");*/
        }
        #endregion


        //
        // Methods
        //
        #region Methods

        //
        // Accounts
        //
        #region Accounts
        public static async Task<bool> Login(string username, string password)
        {
            var salt = await _database.CallSPScalarAsync("Salt", "Accounts_GetSalt",
                new SqlParameter("@Username", SqlDbType.Char, 16) { Value = username.Trim().Truncate(16) });
            if (salt == null) return false;
            var hashed = Hash.ComputeHash(password, Hash.Algorithms["SHA512"], System.Text.Encoding.UTF8.GetBytes(salt.ToString()));
            var table = await _database.CallSPReaderAsync("Account", "Accounts_Login", new SqlParameter("@Username", SqlDbType.Char, 16) { Value = username.Trim().Truncate(16) }, new SqlParameter("@Password", SqlDbType.Char, 96) { Value = hashed });
            _account = new Account(
                (int)table.Rows[0]["AccountID"],
                table.Rows[0]["Username"].ToString().Trim(),
                table.Rows[0]["Password"].ToString().Trim(),
                table.Rows[0]["Salt"].ToString().Trim(),
                table.Rows[0]["AccountType"].ToString().Trim(),
                (bool)table.Rows[0]["Active"]);
            return (salt != null && hashed != null && table != null);
            //var hashed = Hash.ComputeHash(password, Hash.Algorithms["SHA512"], System.Text.Encoding.UTF8.GetBytes(salt.ToString()));
            //System.Threading.Thread.Sleep(1000);
            //return salt != null;
        }

        public static void Logout()
        {
            _account = null;
        }

        public static async Task<bool> UsernameExists(string username)
        {
            var exists = await _database.CallSPScalarAsync("UsernameExists", "Accounts_UsernameExists", new SqlParameter("@Username", SqlDbType.Char, 16) { Value = username.Trim().Truncate(16) });
            return Convert.ToBoolean(exists);
        }

        public static async Task ChangeUsername(string username)
        {
            await _database.CallSPNonQueryAsync("Accounts_ChangeUsername", new SqlParameter("@AccountID", SqlDbType.Int) { Value = _account.ID }, new SqlParameter("@Username", SqlDbType.Char, 16) { Value = username });
        }

        public static async Task ChangePassword(string password)
        {
            await _database.CallSPNonQueryAsync("Accounts_ChangeUsername", new SqlParameter("@AccountID", SqlDbType.Int) { Value = _account.ID }, new SqlParameter("@Password", SqlDbType.Char, 96) { Value = password });
        }

        public static async Task Register(string username, string password)
        {
            byte[] salt;
            Hash.GenerateSalt(out salt);
            await _database.CallSPNonQueryAsync("Accounts_Register",
                new SqlParameter("@Username", SqlDbType.Char, 16) { Value = username },
                new SqlParameter("@Password", SqlDbType.Char, 96) { Value = Hash.ComputeHash(password, Hash.Algorithms["SHA512"], salt) },
                new SqlParameter("@Salt", SqlDbType.Char, 8) { Value = Convert.ToBase64String(salt).Trim() },
                new SqlParameter("@AccountType", SqlDbType.Char, 6) { Value = "NORMAL" },
                new SqlParameter("@Active", SqlDbType.Bit) { Value = 1 });
        }
        #endregion

        //
        // Appliances
        //
        #region Appliances

        public static async Task AddAppliance(string name, string type, double wattage, byte pinID)
        {
            await _database.CallSPNonQueryAsync("Appliances_AddAppliance",
                new SqlParameter("@Name", SqlDbType.Char, 16) { Value = name },
                new SqlParameter("@ApplianceType", SqlDbType.Char, 16) { Value = type },
                new SqlParameter("@Wattage", SqlDbType.Real) { Value = wattage },
                new SqlParameter("@PinID", SqlDbType.TinyInt) { Value = pinID },
                new SqlParameter("@IsDigital", SqlDbType.Bit) { Value = 1 },
                new SqlParameter("@Active", SqlDbType.Bit) { Value = 1 },
                new SqlParameter("@Restricted", SqlDbType.Bit) { Value = 0 },
                new SqlParameter("@AddedBy", SqlDbType.Int) { Value = _account.ID });
        }

        public static async Task EditAppliance(int applianceID, string name, string type, double wattage, byte pinID, bool active, bool restricted)
        {
            await _database.CallSPNonQueryAsync("Appliances_EditAppliance",
                new SqlParameter("@ApplianceID", SqlDbType.Int) { Value = applianceID },
                new SqlParameter("@Name", SqlDbType.Char, 16) { Value = name },
                new SqlParameter("@ApplianceType", SqlDbType.Char, 16) { Value = type },
                new SqlParameter("@Wattage", SqlDbType.Real) { Value = wattage },
                new SqlParameter("@PinID", SqlDbType.TinyInt) { Value = pinID },
                new SqlParameter("@IsDigital", SqlDbType.Bit) { Value = 1 },
                new SqlParameter("@Active", SqlDbType.Bit) { Value = active },
                new SqlParameter("@Restricted", SqlDbType.Bit) { Value = restricted });
        }

        public static async Task SwitchAppliance(int applianceID, Int16 value)
        {
            await _database.CallSPNonQueryAsync("States_ChangeState",
                new SqlParameter("@AccountID", SqlDbType.Int) { Value = _account.ID },
                new SqlParameter("@ApplianceID", SqlDbType.Int) { Value = applianceID },
                new SqlParameter("@Value", SqlDbType.SmallInt) { Value = value });
        }
        #endregion

        //
        // Schedule
        //
        #region Schedule

        public static async Task AddSchedule(int applianceID, bool value, string scheduleType, string repitition, DateTime lowerLimit, DateTime upperLimit)
        {
            await _database.CallSPNonQueryAsync("Schedules_AddSchedule",
                new SqlParameter("@ApplianceID", SqlDbType.Int) { Value = applianceID },
                new SqlParameter("@SetValue", SqlDbType.Bit) { Value = value },
                new SqlParameter("@ScheduleType", SqlDbType.Char, 16) { Value = scheduleType },
                new SqlParameter("@Repitition", SqlDbType.Char, 7) { Value = repitition },
                new SqlParameter("@LowerLimit", SqlDbType.DateTime) { Value = lowerLimit },
                new SqlParameter("@UpperLimit", SqlDbType.DateTime) { Value = upperLimit });
        }

        public static async Task EditSchedule(int scheduleID, int applianceID, bool value, string scheduleType, string repitition, DateTime lowerLimit, DateTime upperLimit)
        {
            await _database.CallSPNonQueryAsync("Schedules_AddSchedule",
                new SqlParameter("@ScheduleID", SqlDbType.Int) { Value = scheduleID },
                new SqlParameter("@ApplianceID", SqlDbType.Int) { Value = applianceID },
                new SqlParameter("@SetValue", SqlDbType.Bit) { Value = value },
                new SqlParameter("@ScheduleType", SqlDbType.Char, 16) { Value = scheduleType },
                new SqlParameter("@Repitition", SqlDbType.Char, 7) { Value = repitition },
                new SqlParameter("@LowerLimit", SqlDbType.DateTime) { Value = lowerLimit },
                new SqlParameter("@UpperLimit", SqlDbType.DateTime) { Value = upperLimit });
        }
        #endregion

        //
        // Log
        //
        #region Log

        public static async Task Log(int accountID, string importance, string message)
        {
            await _database.CallSPNonQueryAsync("Logs_Log",
                new SqlParameter("@AccountID", SqlDbType.Int) { Value = accountID },
                new SqlParameter("@Importance", SqlDbType.Char, 8) { Value = importance },
                new SqlParameter("@Message", SqlDbType.VarChar, 100) { Value = message });
        }
        #endregion
        #endregion
    }
}
