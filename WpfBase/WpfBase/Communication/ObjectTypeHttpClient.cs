using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfBase.Utility;

namespace WpfBase.Communication
{
    public delegate string Serializer(object obj);

    public delegate dynamic Parser(string str);

    class ObjectTypeHttpClient : HttpClient
    {
        public ObjectTypeHttpClient(Serializer serialize, Parser parse, string endpoint = null)
            :base(endpoint)
        {
            _serialize = serialize;
            _parse = parse;
        }

        private readonly Serializer _serialize;
        private readonly Parser _parse;

        public async Task<HttpResponce> PostAsync(string url, object obj)
        {
            return await Task.Run(() => Post(url, obj));
        }
        public async Task<HttpResponce> PutAsync(string url, object obj)
        {
            return await Task.Run(() => Put(url, obj));
        }

        public HttpResponce Post(string url, object obj)
        {
            try
            {
                var res = post(url, _serialize(obj), "application/json");
                return new HttpResponce
                {
                    Data = _parse(res),
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }

        public HttpResponce Put(string url, object obj)
        {
            try
            {
                var res = put(url, _serialize(obj), "application/json");
                return new HttpResponce
                {
                    Data = _parse(res),
                    Status = WebExceptionStatus.Success
                };
            }
            catch (WebException e)
            {
                return getHttpResponce(e);
            }
        }
    }
}
