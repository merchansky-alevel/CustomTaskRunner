using System;
using Helpers;


namespace TasksRepository
{
    public abstract class SprintTask
    {
        public const int priority=1;
        private double _timeForFix;
        public string _name;

        public bool IsItFixed { get; set; }
        public virtual double Priority { get; } = priority;

        public abstract TypeOfTasks TypeOfTasks { get; }


        public double TimeForFix
        {
            get { return _timeForFix; }
            set
            {
                if (value == 1) 
                {
                    _timeForFix = Math.Ceiling(value * Priority);
                }
                else if ((value == 2) || (value == 3) || (value == 4) || (value == 5))
                {
                    _timeForFix = Math.Ceiling(Math.Ceiling(value + ((value*0.1)*value))* Priority);
                }
                else
                    throw new ArgumentException("Parameter can have only value: 1, 2, 3, 4, 5");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    throw new ArgumentNullException("Value can not be null");
            }
        }

        public SprintTask(int complexity, string name = "BlaBlaBla")
        {
            TimeForFix =complexity ;
            Name = name;
        }

        public void FixIssue (int velocity=1)
        {
            if (!IsItFixed)
                _timeForFix = _timeForFix - velocity;
            else throw new InvalidOperationException("The issue is alreade fixed");
        }

        public void MoveTaskToResolve ()
        {
                IsItFixed = true;
        }
    }
}
