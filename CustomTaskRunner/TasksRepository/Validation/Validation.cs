using System;

namespace TasksRepository
{
    public class DataValidation
    {
        public bool RunWithComplexity(string complexity) => CheckComplexity(complexity);

        public bool RunWithName(string name) => CheckName(name);

        private bool CheckName(string value)
        {
            return Length(value) > 1 ? true : WithMessage(false, "short name!");
        }

        private bool CheckComplexity(string value)
        {
            return Length(value) > 0 ? Parser(value) : WithMessage(false, "invalid complexity!");
        }

        private bool Parser (string value)
        {
            value = value.IndexOf(".") != -1 ? value.Replace('.', ',') : value;

            return Int32.TryParse(value, out int isInt) || Double.TryParse(value, out double isDouble);
        }

        private bool WithMessage(bool value, string message)
        {
            Console.WriteLine("ERROR: {0}", message);
            return value;
        }

        private int Length(string value) => value.ToString().Length;
    }
}
