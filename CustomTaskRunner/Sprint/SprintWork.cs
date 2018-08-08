using System;
using TasksRepository;


namespace Sprint
{
    public class SprintWork
    {
        public const int NumberOfDevelopers = 1;
        public const int TeamVelosity = 1;
        public const int NumberOfSprints = 30;

        SprintTask [] ScopeOfSprints { get; set; }
        public double ScopeOfStoryPoints { get;}

        public SprintWork (int [] complexity,  string [] nameOfTask, TypeOfTasks [] typeOfTasks)
        {

            ScopeOfSprints = new SprintTask[typeOfTasks.Length];

            for (int i=0; i< ScopeOfSprints.Length; i++)
            {
                switch (typeOfTasks[i])
                {
                    case TypeOfTasks.Bug:
                        ScopeOfSprints[i] = new Bug(complexity[i], nameOfTask[i]);
                        break;
                    case TypeOfTasks.Feature:
                        ScopeOfSprints[i] = new Feature (complexity[i], nameOfTask[i]);
                        break;
                    case TypeOfTasks.TechnicalDept:
                        ScopeOfSprints[i] = new TechnicalDebt (complexity[i], nameOfTask[i]);
                        break;
                }
                ScopeOfStoryPoints += ScopeOfSprints[i].TimeForFix;
            }
        }

        public bool IfGoalsAreReacheble ()
        {
            if (ScopeOfStoryPoints <= NumberOfDevelopers * TeamVelosity * NumberOfSprints)
                return true;
            else return false;
        }

        public void WorkingProcess ()
        {
            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                if (!ScopeOfSprints[i].IsItFixed)
                {
                    ScopeOfSprints[i].FixIssue();
                }
            }
        }

    }
}
