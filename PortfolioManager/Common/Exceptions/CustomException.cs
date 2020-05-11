using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    /// <summary>
    /// Custom exception to re throw from my microservices. Contains custom info for the user.
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// Error code.
        /// </summary>
        public string Code { get; set; }
        public CustomException()
        {
        }
        public CustomException(string code)
        {
            Code = code;
        }
        public CustomException(string message, params object[] args) : this(string.Empty, message, args)
        {

        }
        public CustomException(string code, string message, params object[] args) : this(null, code, message, args)
        {

        }
        public CustomException(Exception innerException, string message, params object[] args) : this(innerException, string.Empty, message, args)
        {

        }
        public CustomException(Exception innerException, string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {

        }
    }
}
