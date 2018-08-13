using System;

namespace CustomTaskRunner
{
    class TaskType
    {
        
        public string Type(string typeNumber)
        {
            string type = string.Empty;

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
