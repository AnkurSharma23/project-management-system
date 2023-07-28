using System.Net;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        protected BadRequestException() :base()
        {
        }

        public BadRequestException(HttpStatusCode statusCode, string reasonPhrase)
            : base($"{statusCode}:{reasonPhrase}")
        {
        }

        public BadRequestException(HttpStatusCode statusCode, string reasonPhrase, Exception innerException)
            : base($"{statusCode}:{reasonPhrase}", innerException)
        {
        }
    }
}
