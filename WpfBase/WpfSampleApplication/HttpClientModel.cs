using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfBase;
using WpfBase.Communication;
using WpfSampleApplication.Annotations;

namespace WpfSampleApplication
{
    class HttpClientModel : NotifyPropertyChangedBase
    {
        public HttpClientModel()
        {
            ContentTypeText = "text/plain";
            _client = new HttpClient();
        }

        public async void Get()
        {
            ConsoleText = "Start GET ...";
            try
            {
                var res = await _client.GetAsync(EndpointText, ContentDataText);
                ConsoleText = res.Status + "\n" + res.String;
            }
            catch (Exception e)
            {
                ConsoleText = "Error: " + e.Message;
            }          
        }

        public async void Post()
        {
            ConsoleText = "Start POST ...";
            try
            {
                var res = await _client.PostAsync(EndpointText, ContentDataText, ContentTypeText);
                ConsoleText = res.Status + "\n" + res.String;
            }
            catch (Exception e)
            {
                ConsoleText = "Error: " + e.Message;
            }      
        }

        public async void Put()
        {
            ConsoleText = "Start PUT ...";
            try
            {
                var res = await _client.PutAsync(EndpointText, ContentDataText, ContentTypeText);
                ConsoleText = res.Status + "\n" + res.String;
            }
            catch (Exception e)
            {
                ConsoleText = "Error: " + e.Message;
            }
           
        }

        public async void Delete()
        {
            ConsoleText = "Start DELETE ...";
            try
            {
                var res = await _client.DeleteAsync(EndpointText, ContentDataText);
                ConsoleText = res.Status + "\n" + res.String;
            }
            catch (Exception e)
            {
                ConsoleText = "Error: " + e.Message;
            }
        }

        #region Binding Properties
        public string ContentTypeText { get; set; }

        public string ContentDataText { get; set; }

        public string EndpointText { get; set; }

        public string ConsoleText
        {
            get { return _consoleText; }
            private set
            {
                _consoleText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Private Members
        private string _consoleText;
        private readonly HttpClient _client;
        #endregion
    }
}
