using System;
using TasksRepository;
using BoolRandomizer;


namespace Sprint
{
    public class SprintWork
    {
        public const int NumberOfDevelopers = 1;
        public const int DeveloperVelocity = 1;
        public const int TeamVelosity = NumberOfDevelopers*DeveloperVelocity;
        public const int NumberOfSprints = 30;

        SprintTask [] ScopeOfSprints { get; set; }
        public double ScopeOfStoryPoints { get;}
        private int _sprintsBeforeRelease;

        public int SprintsBeforeRelease { get; set; }

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
            SprintsBeforeRelease = NumberOfSprints;
        }

        public bool IfGoalsAreReacheble ()
        {
            if (ScopeOfStoryPoints <= NumberOfSprints)
                return true;
            else return false;
        }

        public void WorkingProcess (out string [] logs)
        {
            logs = new string[1000];
            int logsCounter = 0;

                for (int i = 0; i < ScopeOfSprints.Length; i++)
                {
                    if (ScopeOfSprints[i].TimeForFix>0)
                    {
                        for (int j = 0; j < ScopeOfSprints[i].TimeForFix; j++)
                       {
                        if (SprintsBeforeRelease != 0)
                        {
                            if (!Randomizer.BoolRandomizerInitial())
                            {
                                ScopeOfSprints[i].FixIssue();
                                logs[logsCounter] = $"Developer was working with issue {ScopeOfSprints[i].Name}. The part of the issue was fixed successfully";
                                logsCounter++;
                                SprintsBeforeRelease--;
                            }
                            else
                            {
                                logs[logsCounter] = $"Developer was working with issue {ScopeOfSprints[i].Name}. The part of the issue was returned by QA";
                                logsCounter++;
                                SprintsBeforeRelease--;
                            }
                        }
                        else
                            break;
                        }
                     }
                 }
        }

    }
}
