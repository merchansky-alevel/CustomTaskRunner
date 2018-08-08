using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class Feature : Task
    {
        public Feature(string name, double timeForFix) : base(name, timeForFix) { }
        public override double Priority
        {
            get { return priority*2; }
        }
    }
}
