using System.Net;

namespace ING_Recruitment_Task.Utilities.Exceptions
{
    public class NbpServiceException : Exception
    {
        public HttpStatusCode Code { get; private set; }
        public NbpServiceException(HttpStatusCode code, string message) : base(message) 
        {
            Code = code;
        }
    }
}
