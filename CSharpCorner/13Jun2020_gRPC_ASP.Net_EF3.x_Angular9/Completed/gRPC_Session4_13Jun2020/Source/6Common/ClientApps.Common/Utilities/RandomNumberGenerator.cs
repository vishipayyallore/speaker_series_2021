using System;

namespace ClientApps.Common.Utilities
{

    public static class RandomNumberGenerator
    {
        static readonly Random _random = new Random();

        static public int GetRandomValue(int start = 8, int end = 50)
        {
            return _random.Next(start, end);
        }
    }

}
