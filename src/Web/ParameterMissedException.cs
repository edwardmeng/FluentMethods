namespace System.Web
{
    /// <summary>
    /// The exception for the missed page parameter.
    /// </summary>
    [Serializable]
    public class ParameterMissedException : ApplicationException
    {
        private readonly string _paramName;
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMissedException"/> class.
        /// </summary>
        public ParameterMissedException()
            : base("The request parameter was missed.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMissedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ParameterMissedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMissedException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        protected ParameterMissedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            _paramName = info.GetString("ParamName");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMissedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParameterMissedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMissedException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public ParameterMissedException(string paramName, string message)
            : base(message)
        {
            _paramName = paramName;
        }

        /// <summary>
        /// Sets the <see cref="System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic).
        /// </exception>
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            base.GetObjectData(info, context);
            info.AddValue("ParamName", _paramName, typeof(string));
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        public override string Message
        {
            get
            {
                var message = base.Message;
                if (!string.IsNullOrEmpty(_paramName))
                {
                    return message + Environment.NewLine + $"Required request parameter '{_paramName}' was missed.";
                }
                return message;
            }
        }
    }
}
