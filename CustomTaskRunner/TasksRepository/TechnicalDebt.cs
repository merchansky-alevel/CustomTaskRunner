using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class TechnicalDebt : Task
    {
        public TechnicalDebt(string name, int complexity)
        {
            Name = name;
            Complexity = complexity;
            _priority = 0.5;
        }
    }
}
