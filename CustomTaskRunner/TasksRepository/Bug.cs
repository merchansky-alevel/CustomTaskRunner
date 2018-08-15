using Helpers;

namespace TasksRepository
{
    public class Bug : SprintTask
    {
        public override double Priority { get; } = priority*2;
        public override TypeOfTasks TypeOfTasks { get; } = TypeOfTasks.Bug;

        public Bug(int complexity, string name) : base(complexity, name)
        {
        }

    }
}
