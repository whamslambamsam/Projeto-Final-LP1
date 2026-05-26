using System;
using Spectre.Console;

namespace Blackout
{
    public class Program
    {
        private static void Main(string[] args)
        {
            View difficulty = new View();
            difficulty.DifficultySelect();
        }
    }
}
