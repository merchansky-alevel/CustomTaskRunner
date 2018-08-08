using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomTaskRunner
{
    class SprintTask
    {
        string name;
        string type;
        int complexity;

        public SprintTask (string type, string name, int complexity)
        {
            this.type = type;
            this.name = name;
            this.complexity = complexity;
        }
    }
}
