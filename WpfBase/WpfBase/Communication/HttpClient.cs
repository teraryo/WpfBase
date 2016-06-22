using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfBase.Utility;

namespace WpfBase.Communication
{
    public static class HttpClient
    {
        private static int TIMEOUT = 10000;

        public static void SetTimeOut(int timeout)
        {
            TIMEOUT = timeout;
        }

        public async static Task<string> PostAsync(string url, string data, string contentType)
        {
            return await Task.Run(() => Post(url, data, contentType));
        }
        public async static Task<string> PutAsync(string url, string data, string contentType)
        {
            return await Task.Run(() => Put(url, data, contentType));
        }
        public async static Task<string> GetAsync(string url, string data = "")
        {
            return await Task.Run(() => Get(url, data));
        }
        public async static Task<string> DeleteAsync(string url, string data = "")
        {
            return await Task.Run(() => Delete(url, data));
        }

        public async static Task<dynamic> PostJsonAsync(string url, object obj)
        {
            var str = await PostAsync(url, DynamicJson.Serialize(obj), "application/json");
            return DynamicJson.Parse(str);
        }

        public async static Task<dynamic> PutJsonAsync(string url, object obj)
        {
            var str = await PutAsync(url, DynamicJson.Serialize(obj), "application/json");
            return DynamicJson.Parse(str);
        }

        public static string Post(string url, string data, string contentType)
        {
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

        public static string Put(string url, string data, string contentType)
        {
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

        public static string Get(string url, string data = "")
        {
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

        public static string Delete(string url, string data = "")
        {
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
    }
}
