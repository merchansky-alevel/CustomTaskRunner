using System;


namespace TasksRepository
{
    public abstract class SprintTask
    {
        public const int priority = 1;
        private double _timeForFix;
        
        public string _name;
        public bool IsItFixed { get; set; }

        public virtual double Priority { get { return priority; }}

        public double TimeForFix
        {
            get { return _timeForFix; }
            set
            {
                if (value == 1) 
                {
                    _timeForFix = value;
                }
                else if ((value == 2) || (value == 3) || (value == 4) || (value == 5))
                {
                    _timeForFix = Math.Ceiling(value + ((value*0.1)*value))*priority;
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
            TimeForFix=complexity ;
            Name = name;
        }

        public void FixIssue ()
        {
            if (!IsItFixed)
                _timeForFix--;
        }

        public void MoveTaskToResolve ()
        {
            if (_timeForFix == 0)
                IsItFixed = true;

        }

    }
}
