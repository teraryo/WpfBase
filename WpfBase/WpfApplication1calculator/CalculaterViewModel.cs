using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfBase;

namespace WpfApplication1calculator
{
    class CalculaterViewModel : ViewModelBase
    {
        private Calcurator _model = new Calcurator();
        public string NumberText
        {
            get { return _model.Number; }
        }
        public string OperatorText
        {
            get { return _model.Operator; }
        }
        public ICommand AddNumberCommand
        {
            get
            {
                return new SimpleCommand(param =>
                {
                    _model.AddNumber(int.Parse(param.ToString()));
                    OnPropertyChanged("NumberText");
                    OnPropertyChanged("OperatorText");
                });
            }
        }
    }
}
public ICommand AddCommand
{
    get
    {
        return new SimpleCommand(Param =>
  {
      _model.Add();
      _model.SubStruct();
      _model.Multiple();
      _model.Devid();
      _model.Enter();
  });
    }
}






