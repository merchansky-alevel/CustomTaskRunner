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
        public const double priority = 1;
        private double _timeForFix;

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name cannot be empty or null. Please input name of a task.");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public virtual double Priority
        {
            get { return 1; }
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
                else if (value == 2 || value == 3 || value == 4 || value == 5)
                {
                    _timeForFix = Math.Ceiling(value + ((value * 0.1) * value));
                }
                else
                {
                    throw new ArgumentException("Invalid input. Input value: 1, 2, 3, 4 or 5.");
                }
            }
        }
        public  Task(string name, double timeForFix)
        {
            Name = name;
            TimeForFix = timeForFix;
        }
        public void FixedOneTask()
        {
            _timeForFix--;
        }
    }
}
