using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WpfBase.Utility;

namespace WpfBase.Communication
{

    public class HttpClient
    {
        public HttpClient(string endpoint = null)
        {
            TIMEOUT = 10000;
            _endpoint = endpoint;
        }
        public int TIMEOUT { get; set; }

        public async Task<HttpResponce> PostAsync(string url, string data, string contentType)
        {
            return await Task.Run(() => Post(url, data, contentType));
        }
        public async Task<HttpResponce> PutAsync(string url, string data, string contentType)
        {
            return await Task.Run(() => Put(url, data, contentType));
        }
        public async Task<HttpResponce> GetAsync(string url, string data = "")
        {
            return await Task.Run(() => Get(url, data));
        }
        public async Task<HttpResponce> DeleteAsync(string url, string data = "")
        {
            return await Task.Run(() => Delete(url, data));
        }

        public HttpResponce Post(string url, string data, string contentType)
        {
            try
            {
                var res = post(url, data, contentType);
                return new HttpResponce
                {
                    Data = res,
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }
        public HttpResponce Put(string url, string data, string contentType)
        {
            try
            {
                var res = put(url, data, contentType);
                return new HttpResponce
                {
                    Data = res,
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }

        public HttpResponce Get(string url, string data)
        {
            try
            {
                var res = get(url, data);
                return new HttpResponce
                {
                    Data = res,
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }
        public HttpResponce Delete(string url, string data)
        {
            try
            {
                var res = delete(url, data);
                return new HttpResponce
                {
                    Data = res,
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }
        #region Private Members

        private readonly string _endpoint;
        protected string post(string url, string data, string contentType)
        {
            url = _endpoint + url;
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nPOST DATA\n" + data);
            Console.WriteLine("URL\n" + url);
            byte[] putDataBytes = Encoding.ASCII.GetBytes(data);

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Timeout = TIMEOUT;
            req.Method = "POST";
            req.ContentType = contentType;
            req.ContentLength = putDataBytes.Length;

            System.IO.Stream reqStream = req.GetRequestStream();
            reqStream.Write(putDataBytes, 0, putDataBytes.Length);
            reqStream.Close();

            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            sr.Close();
            return str;
        }

        protected string put(string url, string data, string contentType)
        {
            url = _endpoint + url;
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nPUT DATA\n" + data);
            Console.WriteLine("URL\n" + url);
            byte[] putDataBytes = Encoding.ASCII.GetBytes(data);

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Timeout = TIMEOUT;
            req.Method = "PUT";
            req.ContentType = contentType;
            req.ContentLength = putDataBytes.Length;

            System.IO.Stream reqStream = req.GetRequestStream();
            reqStream.Write(putDataBytes, 0, putDataBytes.Length);
            reqStream.Close();

            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            sr.Close();
            return str;
        }

        private string get(string url, string data = "")
        {
            url = _endpoint + url;
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nGET DATA\n" + data);
            Console.WriteLine("URL\n" + url);

            if (!string.IsNullOrEmpty(data))
                url = url + "?" + data;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Timeout = TIMEOUT;
            req.Method = "GET";

            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            sr.Close();
            return str;
        }

        private string delete(string url, string data = "")
        {
            url = _endpoint + url;
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nDELETE DATA\n" + data);
            Console.WriteLine("URL\n" + url);

            if (!string.IsNullOrEmpty(data))
                url = url + "?" + data;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Timeout = TIMEOUT;
            req.Method = "DELETE";

            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            sr.Close();
            return str;
        }

        protected HttpResponce getHttpResponce(WebException e)
        {
            var responce = new HttpResponce();
            responce.Status = e.Status;
            try
            {
                responce.Data = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception)
            {
            }
            return responce;
        }
        #endregion
    }
}
