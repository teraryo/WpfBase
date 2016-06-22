using System;
using System.Text;
using WpfBase.Utility;

namespace WpfBase.Communication
{
    static class Http
    {
        public static dynamic Post(object obj, string url)
        {
            //文字コードを指定する
            var enc = Encoding.GetEncoding("utf-8");

            //POST送信する文字列を作成
            string postData = DynamicJson.Serialize(obj);
            Console.WriteLine("\nPOST DATA\n" + postData);
            Console.WriteLine("URL\n" + url);
            //バイト型配列に変換
            byte[] postDataBytes = Encoding.ASCII.GetBytes(postData);

            //WebRequestの作成
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);

            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/application/json"にする
            req.ContentType = "application/json";
            //POST送信するデータの長さを指定
            req.ContentLength = postDataBytes.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.WebResponse res = req.GetResponse();
            req.Timeout = 10000;
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            //閉じる
            sr.Close();
            dynamic json = DynamicJson.Parse(str);
            // Writer.WriteLine("PARSED JSON\n" + json);

            return json;
        }

        public static dynamic Put(object obj, string url)
        {
            //文字コードを指定する
            var enc = Encoding.GetEncoding("utf-8");
            //PUT送信する文字列を作成
            string postData = DynamicJson.Serialize(obj);
            Console.WriteLine("\nPUT DATA\n" + postData);
            Console.WriteLine("URL\n" + url);
            //バイト型配列に変換
            byte[] putDataBytes = Encoding.ASCII.GetBytes(postData);

            //WebRequestの作成
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Timeout = 10000;
            //メソッドにPUTを指定
            req.Method = "PUT";
            //ContentTypeを"application/application/json"にする
            req.ContentType = "application/json";
            //PUT送信するデータの長さを指定
            req.ContentLength = putDataBytes.Length;

            //データをPUT送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(putDataBytes, 0, putDataBytes.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();

            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            string str = sr.ReadToEnd();
            Console.WriteLine("\nRESPONCE DATA\n" + str);
            //閉じる
            sr.Close();
            dynamic json = DynamicJson.Parse(str);
            // Writer.WriteLine("PARSED JSON\n" + json);

            return json;
        }
    }
}
