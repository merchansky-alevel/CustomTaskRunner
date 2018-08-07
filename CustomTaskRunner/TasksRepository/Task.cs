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
        private double _priority;
        private double _timeForFix;
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
        public virtual double Priority
        {
            get { return _priority=1; }
        }

        public double TimeForFix
        {
            get { return _timeForFix; }
            set
            {
                if (value == 1)
                {
                    _timeForFix = value;
                    
                }
                if (value == 2 || value == 3 || value == 4 || value == 5)
                {
                    _timeForFix = Math.Ceiling(value + ((value * 0.1) * value));
                }
                else
                {
                    throw new ArgumentException("Invalid input. Input value: 1, 2, 3, 4 or 5.");
                }
            }
        }

    }
}
