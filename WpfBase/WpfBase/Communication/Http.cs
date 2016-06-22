using System;
using System.Text;
using WpfBase.Utility;

namespace WpfBase.Communication
{
    static class Http
    {
        private static int TIMEOUT = 10000;

        public static void SetTimeOut(int timeout)
        {
            TIMEOUT = timeout;
        }

        public static dynamic PostJson(object obj, string url)
        {
            var str = Post(DynamicJson.Serialize(obj), url,"application/json");
            return DynamicJson.Parse(str);
        }

        public static dynamic PutJson(object obj, string url)
        {
            var str = Put(DynamicJson.Serialize(obj), url, "application/json");
            return DynamicJson.Parse(str);
        }

        public static string Get(string url)
        {
            return Get("", url);
        }

        public static string Delete(string url)
        {
            return Delete("", url);
        }

        public static string Post(string postData, string url, string contentType)
        {
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nPOST DATA\n" + postData);
            Console.WriteLine("URL\n" + url);
            byte[] putDataBytes = Encoding.ASCII.GetBytes(postData);

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

        public static string Put(string putData, string url, string contentType)
        {
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nPUT DATA\n" + putData);
            Console.WriteLine("URL\n" + url);
            byte[] putDataBytes = Encoding.ASCII.GetBytes(putData);

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

        public static string Get(string getData, string url)
        {
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nGET DATA\n" + getData);
            Console.WriteLine("URL\n" + url);

            if (getData != null)
                url = url + "?" + getData;
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

        public static string Delete(string deleteData, string url)
        {
            var enc = Encoding.GetEncoding("utf-8");
            Console.WriteLine("\nDELETE DATA\n" + deleteData);
            Console.WriteLine("URL\n" + url);

            if (deleteData != null)
                url = url + "?" + deleteData;
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
