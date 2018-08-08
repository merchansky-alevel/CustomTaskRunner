using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class Feature : SprintTask
    {
        public Feature (int complexity, string name) : base(complexity, name) { }
    }
}
