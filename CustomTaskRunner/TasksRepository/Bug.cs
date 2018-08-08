using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class Bug : SprintTask
    {
        public override double Priority { get { return priority*2; } }
        public Bug(int complexity, string name) : base(complexity, name) { }

    }
}
