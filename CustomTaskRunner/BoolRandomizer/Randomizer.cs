using System;
using System.Threading;

namespace BoolRandomizer
{
    public static class Randomizer
    {
        public static bool BoolRandomizerInitial()
        {
            Thread.Sleep(150);
            Random rnd = new Random();
            int i = rnd.Next(0, 100);

            if (i > 20) return false;
            else return true;
        }

        public static bool BoolRandomizerWithArray()
        {
            bool[] array = new bool[1000];

            for (int j=0; j<array.Length - 50; j++)
            {
                array[j] = true;
            }
            for (int j=0; j<array.Length; j++)
            {
                Random rnd1 = new Random();
                int x = rnd1.Next(0, array.Length-1);
                array[j] = array[x];
            }

            Random rnd2 = new Random();
            int z = rnd2.Next(0, array.Length - 1);

            return array [z];
        }
    }
}
