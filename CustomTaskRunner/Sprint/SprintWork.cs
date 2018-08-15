using TasksRepository;
using Helpers;


namespace Sprint
{
    public class SprintWork
    {
        public const int NumberOfSprints = 30;
        public const int TeamVelosity = 1;

        public LogsHelper[] Logs { get; set; }
        public int LogCounter { get; set; }

        static int NumberOfCurrentSprint { get; set; }
        SprintTask[] ScopeOfSprints { get; set; }
        public double ScopeOfStoryPoints { get; }


        static SprintWork()
        {
            NumberOfCurrentSprint = 0;
        }

        public SprintWork(int[] complexity, string[] nameOfTask, TypeOfTasks[] typeOfTasks)
        {
            Logs = new LogsHelper[100];
            ScopeOfSprints = new SprintTask[typeOfTasks.Length];

            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                switch (typeOfTasks[i])
                {
                    case TypeOfTasks.Bug:
                        ScopeOfSprints[i] = new Bug(complexity[i], nameOfTask[i]);
                        break;
                    case TypeOfTasks.Feature:
                        ScopeOfSprints[i] = new Feature(complexity[i], nameOfTask[i]);
                        break;
                    case TypeOfTasks.TechnicalDept:
                        ScopeOfSprints[i] = new TechnicalDebt(complexity[i], nameOfTask[i]);
                        break;
                }
                ScopeOfStoryPoints += ScopeOfSprints[i].TimeForFix;
            }
        }

        public bool IfGoalsAreReachable()
        {
            if (ScopeOfStoryPoints <= NumberOfSprints)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WorkingProcess()
        {
            bool ifNonFixedIssuesExist=false;
            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                if (NumberOfCurrentSprint < NumberOfSprints)
                {
                    AddNewEntryToLog($"We are starting to resolve {ScopeOfSprints[i].TypeOfTasks} {ScopeOfSprints[i].Name}. In best case we will need {ScopeOfSprints[i].TimeForFix} sprint(s) to resolve this issue.", LogTypes.Info);
                    FixingOneIssue(ScopeOfSprints[i]);
                }
            }

            for (int i = 0; i < ScopeOfSprints.Length; i++)
               if (ScopeOfSprints[i].IsItFixed == false) ifNonFixedIssuesExist = true;
            
            if (!ifNonFixedIssuesExist) DisplayingSuccessResults();
            else DisplayingBadResults();
        }

        private void FixingOneIssue(SprintTask sprintTask)
        {
            int realCountOfSprintForResolving = 0;

            while ((sprintTask.TimeForFix > 0) && (NumberOfCurrentSprint < NumberOfSprints))
                {
                NumberOfCurrentSprint++;
                if (!Randomizer.BoolRandomizerInitial())
                {
                    sprintTask.FixIssue(TeamVelosity);
                        AddNewEntryToLog ($"The sprint {NumberOfCurrentSprint}. {sprintTask.TypeOfTasks} {sprintTask.Name}  is in progress. The part of the issue is implemented successfully. We need {sprintTask.TimeForFix} sprint(s) to finish this issue.");
                }
                else
                {
                    AddNewEntryToLog($"The sprint {NumberOfCurrentSprint}. {sprintTask.TypeOfTasks} {sprintTask.Name} is in progress. The part of the issue is returned by QA. We need {sprintTask.TimeForFix} sprint(s) to finish this issue.", LogTypes.Error);
                }

                realCountOfSprintForResolving++;
            }
            if (sprintTask.TimeForFix <= 0)
            {
                sprintTask.MoveTaskToResolve();
                AddNewEntryToLog($"The issue {sprintTask.Name} is resolved. We spent {realCountOfSprintForResolving} sptrint(s) on implementation", LogTypes.Info);
            }
        }

        private void AddNewEntryToLog (string str, LogTypes logTypes = LogTypes.Usual)
        {
            Logs[LogCounter] = new LogsHelper();
            Logs[LogCounter].AddNewLogEntry(str, logTypes);
            LogCounter++;
        }


        private void DisplayingSuccessResults ()
        {
            AddNewEntryToLog($"Congratulations! We managed to finish all scope before release", LogTypes.Success);
            AddNewEntryToLog($"Next issues are fixed:", LogTypes.Info);
            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                AddNewEntryToLog($"{i+1}. {ScopeOfSprints[i].TypeOfTasks} with name {ScopeOfSprints[i].Name}");
            }
        }

        private void DisplayingBadResults()
        {
            AddNewEntryToLog($"Release deadline has come. Bad work. We are not be able to resolve all issues", LogTypes.Error);
            AddNewEntryToLog($"Next issues are resolved:", LogTypes.Info);
            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                if (ScopeOfSprints[i].IsItFixed)
                AddNewEntryToLog($"{i + 1}. {ScopeOfSprints[i].TypeOfTasks} with name {ScopeOfSprints[i].Name}");
            }
            AddNewEntryToLog($"We have failed to resolve:", LogTypes.Info);
            for (int i = 0; i < ScopeOfSprints.Length; i++)
            {
                if (!ScopeOfSprints[i].IsItFixed)
                    AddNewEntryToLog($"{i + 1}. {ScopeOfSprints[i].TypeOfTasks} with name {ScopeOfSprints[i].Name}");
            }
        }
    }
}
