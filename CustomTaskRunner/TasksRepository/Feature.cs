using Helpers;


namespace TasksRepository
{
    public class Feature : SprintTask
     {
        public override TypeOfTasks TypeOfTasks { get; } = TypeOfTasks.Feature;

        public Feature (int complexity, string name) : base(complexity, name)
        {
        }
    }
}
