using System;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;

namespace Blackout
{
    public class Program
    {
        /// <summary>
        /// Groups up each class from the MVC format,
        /// sharing their variables between one another and calling methods
        /// in sequence.
        /// </summary>
        private static void Main(string[] args)
        {
            bool running = true;
            View viewer = new View();
            Controller control = new Controller();
            Model model = new Model();

            Console.WriteLine();
            
            string choice = viewer.DifficultySelect();
            (int rows, int cols) = control.GridBuilder(choice, viewer);
            int touch = control.DifficultyTouch(choice, viewer);

            viewer.Load(rows, cols);
            bool[,] dimensions = model.GridSize(rows, cols);
            (int, int) cursor = control.InitialPos(dimensions);
            control.SquareAssort(dimensions, touch);

            // While loop e HandleInput foram debugged com 
            // ajuda de IA
            while(running == true)
            {
                Console.Clear();

                AnsiConsole.MarkupLine($"\n[blue]Difficulty[/] - {choice}");

                AnsiConsole.MarkupLine("[blue]------------------------------------[/]");

                AnsiConsole.MarkupLine("\n* Arrow keys to move the [yellow]cursor[/];");
                AnsiConsole.MarkupLine("* Space to input choice.");
                AnsiConsole.MarkupLine("\nEmpty the grid to [green]win![/]\n");

                AnsiConsole.MarkupLine("[blue]------------------------------------[/]");
                viewer.GridDraw(dimensions, cursor);
                AnsiConsole.MarkupLine("[blue]------------------------------------[/]");

                cursor = control.HandleInput(cursor); // Grid only updates after
                                                      // input!
            }
        }
    }
}