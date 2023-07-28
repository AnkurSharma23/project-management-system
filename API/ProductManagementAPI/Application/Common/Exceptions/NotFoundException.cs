namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        protected NotFoundException() : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
           : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
           : base($"Entity: \"{name}\" ({key}) was not found.")
        {
        }
    }
}
