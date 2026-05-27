using System;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Spectre.Console;
using static Blackout.View;

namespace Blackout
{
    public class Controller
    {
        /// <summary>
        /// Determines the size of the grid based on
        /// the user's choice given on View's DifficultySelect().
        /// </summary>
        /// <param name="choice">
        /// Argument that uses the user's choice.
        /// </param>
        /// <param name="view">
        /// Argument that calls a variable of the View class.
        /// </param>
        /// <returns>
        /// A Tuple whose values depend on choice's value.
        /// If the user's choice is "Custom", calls methods that ask for further
        /// inputs.
        /// </returns>
        /// <remarks>
        /// Foi usado AI para dar debug e concertar um erro com looping de inputs
        /// A lógica e concepção foi feita por nós, apenas foi usado Inteligência
        /// Artificial para evitar o erro.
        /// </remarks>
        public (int, int) GridBuilder(string choice, View view)
        {
            return choice switch
            {
                "[green]Easy[/]" => (3, 3),
                "[yellow]Medium[/]" => (5, 5),
                "[red]Hard[/]" => (8, 8),
                "Custom" => (view.RequestRow(), view.RequestColumn()),
            };
        }

        public int DifficultyTouch(string choice, View view)
        {
            return choice switch
            {
                "[green]Easy[/]" => 2,
                "[yellow]Medium[/]" => 4,
                "[red]Hard[/]" => 10,
                "Custom" => view.RequestTouch(),
            };
        }

        public void SquareAssort(bool[,] size, int touches)
        {
            Random rng = new Random();

            int length = size.GetLength(0); // IA para saber como ler valores
            int width = size.GetLength(1); // das grids

            // Usado IA para saber como fazer os "touches" aleatórios
            for (int i = 0; i < touches; i++)
            {
                int randCellX = rng.Next(length);
                int randCellY = rng.Next(width);

                size[randCellX, randCellY] = true;

                if (randCellX > 0)
                    size[randCellX - 1, randCellY] = 
                        true;

                if (randCellX < length - 1)
                    size[randCellX + 1, randCellY] = 
                        true;

                if (randCellY > 0)
                    size[randCellX, randCellY - 1] = 
                        true;

                if (randCellY < width - 1)
                    size[randCellX, randCellY + 1] = 
                        true;
            }
        }

        public (int, int) InitialPos(bool[,] size)
        {
            int inputX = size.GetLength(0) / 2;
            int inputY = size.GetLength(1) / 2;  

            return (inputX, inputY);
        }

        public (int, int) FlipCell(bool[,] size, (int, int) cursor)
        {
            int cursorX = cursor.Item1;
            int cursorY = cursor.Item2;
        }

        public (int, int) HandleInput((int, int) cursor)
        {
            int cursorX = cursor.Item1;
            int cursorY = cursor.Item2;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    cursorX--;
                    break;

                case ConsoleKey.DownArrow:
                    cursorX++;
                    break;

                case ConsoleKey.LeftArrow:
                    cursorY--;
                    break;

                case ConsoleKey.RightArrow:
                    cursorY++;
                    break;
                
                case ConsoleKey.Spacebar:
                    FlipCell();
                    break;
            }

            return (cursorX, cursorY);
        }
    }
}