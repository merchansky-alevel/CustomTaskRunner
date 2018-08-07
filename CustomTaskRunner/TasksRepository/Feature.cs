using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class Feature : Task
    {
        private double _priority;
        public Feature(string name, double timeForFix)
        {
            Name = name;
            TimeForFix = timeForFix;
        }
        public override double Priority
        {
            get { return _priority = 2; }
        }


    }
}
