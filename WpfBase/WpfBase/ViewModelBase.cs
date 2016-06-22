using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfBase
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private ModelBase _model;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual ModelBase Model
        {
            get { return _model; }
            set
            {
                _model = value;
                _model.PropertyChanged += OnPropertyChanged;
            }
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
