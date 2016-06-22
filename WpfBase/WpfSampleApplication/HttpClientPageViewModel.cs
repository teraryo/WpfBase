using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfBase;
using WpfBase.Communication;

namespace WpfSampleApplication
{
    class HttpClientPageViewModel : ViewModelBase
    {
        private ICommand _requestCommand;

        private new HttpClientModel Model
        {
            get { return (HttpClientModel) base.Model; }
            set { base.Model = value; }
        }

        public HttpClientPageViewModel()
        {
            Model = new HttpClientModel();
            ContentTypeText = "text/plain";
            GetCommand = new SimpleCommand(param =>
            {
                RequestCommand = new SimpleCommand(Model.Get);
                OnPropertyChanged();
                SetButtonBrush("GET");
            });
            PostCommand = new SimpleCommand(param =>
            {
                RequestCommand = new SimpleCommand(Model.Post);
                OnPropertyChanged();
                SetButtonBrush("POST");
            });
            PutCommand = new SimpleCommand(param =>
            {
                RequestCommand = new SimpleCommand(Model.Post);
                OnPropertyChanged();
                SetButtonBrush("PUT");
            });
            DeleteCommand = new SimpleCommand(param =>
            {
                RequestCommand = new SimpleCommand(Model.Delete);
                OnPropertyChanged();
                SetButtonBrush("DELETE");
            });
        }

        public ICommand GetCommand { get; private set; }
        public ICommand PostCommand { get; private set; }
        public ICommand PutCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        private void SetButtonBrush(string method)
        {
            PutBrush = null;
            PostBrush = null;
            GetBrush = null;
            DeleteBrush = null;
            switch (method)
            {
                case "PUT":
                    PutBrush = new SolidColorBrush(Colors.DodgerBlue);
                    break;
                case "POST":
                    PostBrush = new SolidColorBrush(Colors.DodgerBlue);
                    break;
                case "GET":
                    GetBrush = new SolidColorBrush(Colors.DodgerBlue);
                    break;
                case "DELETE":
                    DeleteBrush = new SolidColorBrush(Colors.DodgerBlue);
                    break;
            }
            OnPropertyChanged("PutBrush");
            OnPropertyChanged("PostBrush");
            OnPropertyChanged("GetBrush");
            OnPropertyChanged("DeleteBrush");
        }

        public ICommand RequestCommand
        {
            get { return _requestCommand; }
            private set
            {
                _requestCommand = value;
                OnPropertyChanged();
            }
        }

        public string ConsoleText
        {
            get { return Model.ConsoleText; }
            private set
            {
                Model.ConsoleText = value;
            }
        }

        public string EndpointText
        {
            get { return Model.EndpointText; }
            set { Model.EndpointText = value; }
        }

        public string ContentDataText
        {
            get { return Model.ContentDataText; }
            set { Model.ContentDataText = value; }
        }

        public string ContentTypeText
        {
            get { return Model.ContentTypeText; }
            set { Model.ContentTypeText = value; }
        }

        public SolidColorBrush PostBrush { get; set; }
        public SolidColorBrush PutBrush { get; set; }
        public SolidColorBrush GetBrush { get; set; }
        public SolidColorBrush DeleteBrush { get; set; }
    }
}
