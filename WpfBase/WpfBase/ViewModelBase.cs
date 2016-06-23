using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfBase
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private readonly NotifyPropertyChagedModelBase _model;
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModelBase()
        {
        }

        protected ViewModelBase(NotifyPropertyChagedModelBase model)
        {
            _model = model;
            _model.PropertyChanged += OnPropertyChanged;
        }

        protected virtual NotifyPropertyChagedModelBase Model
        {
            get { return _model; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
