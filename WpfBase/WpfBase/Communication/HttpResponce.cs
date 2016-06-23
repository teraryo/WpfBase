using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
