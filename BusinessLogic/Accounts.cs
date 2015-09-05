using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Account
    {
        //
        // Fields and Properties
        //
        #region Fields and Properties

        /// <summary>
        /// Gets the unique identifier for the account.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets or sets the salt for hashing password.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets the account type.
        /// </summary>
        public string AccountType { get; private set; }

        /// <summary>
        /// Gets the state of the account.
        /// </summary>
        public bool IsActive { get; set; }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="salt">Salt.</param>
        /// <param name="accountType">AccountType.</param>
        /// <param name="isActive">Is the account active.</param>
        public Account(int id, string username, string password, string salt, string accountType, bool isActive)
        {
            ID = id;
            Username = username;
            Password = password;
            Salt = salt;
            AccountType = accountType;
            IsActive = isActive;
        }
        #endregion


        //
        // Static Methods
        //
        #region Static Methods

        //
        // TODO: use await and async
        //
        public static Account GetAccount()
        {

            return null;
        }
        #endregion
    }
}
