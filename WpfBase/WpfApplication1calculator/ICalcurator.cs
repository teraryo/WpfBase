using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1calculator
{
    interface ICalcurator
    {
        void Add();
        void Substract();
        void Multiple();
        void Divide();
        void Enter();
        void AddNumber(int num);
        string Number { get; }
        string Operator { get; }
    }
}
