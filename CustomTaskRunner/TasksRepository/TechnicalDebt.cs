using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class TechnicalDebt : Task
    {
        private double _priority;
        public override double Priority
        {
            get
            {
                return _priority = 0.5;
            }
        }
        public TechnicalDebt(string name, double timeForFix)
        {
            Name = name;
            TimeForFix = timeForFix;
        }

    }
}
