using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class TechnicalDebt : Task
    {
        public override double Priority
        {
            get
            {
                return priority * 0.5;
            }
        }
        public TechnicalDebt(string name, double timeForFix)
        {
            Name = name;
            TimeForFix = timeForFix;
        }
    }
}
