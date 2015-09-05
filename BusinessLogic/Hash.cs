using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace BusinessLogic
{
    /// <summary>
    /// Provides hash functionalities.
    /// </summary>
    /// <remarks>
    /// NOTE: This class is underconstruction as well as the entire assembly.
    /// </remarks>
    public static class Hash
    {
        //
        // Fields and Properties
        //
        #region Fields and Properties

        /// <summary>
        /// Contains the dicitonary of algorithms derived from HashAlgorithm base class.
        /// </summary>
        public static Dictionary<string, HashAlgorithm> Algorithms { get; private set; }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Initializes this class instance once.
        /// </summary>
        static Hash()
        {
            Refresh();
        }
        #endregion


        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// Reinitializes all algorithms in the array 
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void Refresh()
        {
            Algorithms = new Dictionary<string, HashAlgorithm>();
            Algorithms.Add("MD5", new MD5CryptoServiceProvider());
            Algorithms.Add("RIPEMD160", new RIPEMD160Managed());
            Algorithms.Add("SHA1", new SHA1Managed());
            Algorithms.Add("SHA256", new SHA256Managed());
            Algorithms.Add("SHA384", new SHA384Managed());
            Algorithms.Add("SHA512", new SHA512Managed());
        }

        /// <summary>
        /// Generates a salt using random number generator and converts it into byte array.
        /// </summary>
        /// <param name="saltBytes">The byte array to be used.</param>
        /// <param name="minimumLength">Minimum length of the salt.</param>
        /// <param name="maximumLength">Maximum length of the salt.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void GenerateSalt(out byte[] saltBytes, int minimumLength = 4, int maximumLength = 8)
        {
            saltBytes = new byte[(new Random()).Next(4, 8)];
            (new RNGCryptoServiceProvider()).GetNonZeroBytes(saltBytes);
        }

        /// <summary>
        /// Generates a hash for the given plain text value and returns a 
        /// base64-encoded result.
        /// </summary>
        /// <param name="text">Plaintext value to be hashed. The function does not check whether this parameter is null.</param>
        /// <param name="hashAlgorithm">Hash algorithm to be used.</param>
        /// <returns>Hash value formatted as a base64-encoded string.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Text.EncoderFallbackException"></exception>
        /// <exception cref="System.ObjectDisposedException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static string ComputeHash(string text, HashAlgorithm hashAlgorithm)
        {
            Refresh();
            if (hashAlgorithm == null)
                throw new ArgumentNullException("hashAlgorithm");
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(text)));
        }

        /// <summary>
        /// Generates a hash for the given plain text value and returns a 
        /// base64-encoded result. Before the hash is computed, a random salt 
        /// is generated and appended to the plain text. This salt is stored at 
        /// the end of the hash value, so it can be used later for hash 
        /// verification.
        /// </summary>
        /// <param name="text">Plaintext value to be hashed. The function does not check whether this parameter is null.</param>
        /// <param name="hashAlgorithm">Hash algorithm to be used.</param>
        /// <param name="saltBytes">Salt bytes. This parameter can be null, in which case a random salt value will be generated.</param>
        /// <returns>Hash value formatted as a base64-encoded string.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Text.EncoderFallbackException"></exception>
        /// <exception cref="System.ObjectDisposedException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static string ComputeHash(string text, HashAlgorithm hashAlgorithm, byte[] saltBytes)
        {
            Refresh();
            if (saltBytes == null)
                throw new ArgumentNullException("saltBytes");
            if (hashAlgorithm == null)
                throw new ArgumentNullException("hashAlgorithm");

            byte[] hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            byte[] hashBytesWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            for (int i = 0; i < hashBytes.Length; i++)
                hashBytesWithSaltBytes[i] = hashBytes[i];

            for (int i = 0; i < saltBytes.Length; i++)
                hashBytesWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            return Convert.ToBase64String(hashBytesWithSaltBytes);
        }
        #endregion
    }
}
