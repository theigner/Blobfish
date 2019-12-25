namespace Blobfish
{
    using System;

    /// <summary>
    /// The exception that is thrown when a type is used that is now allowed in the intended context.
    /// </summary>
    public class TypeNotAllowedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the TypeNotAllowedException class.
        /// </summary>
        public TypeNotAllowedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TypeNotAllowedException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public TypeNotAllowedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TypeNotAllowedException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException is a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public TypeNotAllowedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
