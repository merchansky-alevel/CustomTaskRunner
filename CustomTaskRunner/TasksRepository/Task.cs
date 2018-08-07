using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public abstract class Task
    {
        private string _name;
        protected double _priority;
        private int _complexity;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != String.Empty)
                {
                    _name = value;
                }

                else
                {
                    _name = "Unknown";
                }
            }
        }
        public int Complexity
        {
            get { return _complexity; }
            set
            {
                if (value<1||value>5)
                {
                    throw new ArgumentException("Unexpected value. Enter only valid complexity value: 1, 2, 3, 4 or 5");
                }
                else
                {
                    _complexity = value;

                }
            }
        }

    }
}
