using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksRepository
{
    public class TechnicalDebt : SprintTask
    {
        public override double Priority { get { return priority * 0.5; } }
        public TechnicalDebt(int complexity, string name) : base(complexity, name) { }
    }
}
