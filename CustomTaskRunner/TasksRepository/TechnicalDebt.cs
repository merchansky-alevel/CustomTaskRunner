using Helpers;

namespace TasksRepository
{
    public class TechnicalDebt : SprintTask
    {
        public override TypeOfTasks TypeOfTasks { get; } = TypeOfTasks.TechnicalDept;
        public override double Priority { get; } = priority*0.5;


        public TechnicalDebt(int complexity, string name) : base(complexity, name)
        {

        }
    }
}
