using System.Net;

namespace WpfBase.Communication
{
    public class HttpResponce
    {
        public dynamic Data { get; set; }
        public string String
        {
            get
            {
                return (Data ?? "").ToString();
            }
        }
        public WebExceptionStatus Status { get; set; }
    }
}
