
namespace WpfBase
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        private readonly NotifyPropertyChangedBase _model;

        protected ViewModelBase()
        {
        }

        protected ViewModelBase(NotifyPropertyChangedBase model)
        {
            _model = model;
            _model.PropertyChanged += OnPropertyChanged;
        }

        protected virtual NotifyPropertyChangedBase Model
        {
            get { return _model; }
        }

        protected virtual void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
