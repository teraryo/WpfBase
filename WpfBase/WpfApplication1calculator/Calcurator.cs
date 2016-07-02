using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1calculator
{
    delegate double Myfunc(double num1, double num2);

    class Calcurator : ICalcurator
    {
        private Myfunc _func;
        private double _number1 = 0;

        private int _number2 = 0;

        private double _answer;
        private int _i = 1;
        public string Number
        {
            get
            {
                switch (_i)
                {
                    case 1:
                        return _number1.ToString();
                    case 2:
                        return _number2.ToString();
                    case 3:
                        return _answer.ToString();
                    default:
                        return "";
                }

            }
        }



        public string Operator
        { get; private set; }


        public void Add()
        {
            {
                _func = (num1, num2) => { return num1 + num2; };
                _i = 2;
                Operator = "+";
            }
        }

        public void AddNumber(int num)
        {
            switch (_i)
            {
                case 1:
                    _number1 = double.Parse(_number1.ToString() + num.ToString());
                    break;
                case 2:
                    _number2 = int.Parse(_number2.ToString() + num.ToString());

                    break;

            }
        }

        public void Divide()
        {
            _func = (num1, num2) => { return num1 / num2; };
            _i = 2;
            Operator = "/";
        }

        public void Enter()
        {  if(_func!=null)
            _answer = _func((double)_number1, (double)_number2);
            _i = 3;
            _func = null;
        }

        public void Multiple()
        {
            _func = (num1, num2) => { return num1 * num2; };
            _i = 2;
            Operator = "*";
        }

        public void Substract()
        {
            _func = (num1, num2) => { return num1 - num2; };
            _i = 2;
            Operator = "-";
        }
    }
}
