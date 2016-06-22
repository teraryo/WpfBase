using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfBase;
using WpfBase.Communication;
using WpfSampleApplication.Annotations;

namespace WpfSampleApplication
{
    class HttpClientModel:ModelBase
    {
        public HttpClientModel()
        {
            ContentTypeText = "text/plain";
        }

        public async void Get()
        {
            ConsoleText = "Start GET ...";
            try
            {
                ConsoleText = await HttpClient.GetAsync(EndpointText, ContentDataText);
            }
            catch (Exception e)
            {
                ConsoleText = "Failed" + e;
            }
        }

        public async void Post()
        {
            ConsoleText = "Start POST ...";
            try
            {
                ConsoleText = await HttpClient.PostAsync(EndpointText, ContentDataText, ContentTypeText);
            }
            catch (Exception e)
            {
                ConsoleText = "Failed" + e;
            }
        }

        public async void Put()
        {
            ConsoleText = "Start PUT ...";
            try
            {
                ConsoleText = await HttpClient.PutAsync(EndpointText, ContentDataText, ContentTypeText);
            }
            catch (Exception e)
            {
                ConsoleText = "Failed" + e;
            }
        }

        public async void Delete()
        {
            ConsoleText = "Start DELETE ...";
            try
            {
                ConsoleText = await HttpClient.DeleteAsync(EndpointText, ContentDataText);
            }
            catch (Exception e)
            {
                ConsoleText = "Failed" + e;
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
        #endregion
    }
}
