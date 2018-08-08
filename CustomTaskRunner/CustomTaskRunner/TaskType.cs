using System;

namespace CustomTaskRunner
{
    class TaskType
    {
        string type;
        public string Type(string typeNumber)
        {
            switch (typeNumber)
            {
                case "1":
                    type = "Bug";
                    break;
                case "2":
                    type = "Feature";
                    break;
                case "3":
                    type = "TechnicalDept";
                    break;
                default:
                    Console.WriteLine("Sorry, we don't have this task type. Please, check your input");
                    break;

            }
            return type;
        }
    }
}
