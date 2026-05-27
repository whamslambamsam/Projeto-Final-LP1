using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    public class View
    {
        /// <summary>
        /// Method that generates a table with Spectre.Console, displaying the
        /// difficulty options and allowing the user to choose with an interactive
        /// UI, also using Spectre.Console.
        /// </summary>
        /// <returns>
        /// The user's choice.
        /// </returns>
        public string DifficultySelect()
        {
            Table table = new Table();
                table.AddColumn("Difficulty");
                table.AddColumn("Size");
                table.AddRow("[green]Easy[/]", "3 x 3");
                table.AddRow("[yellow]Medium[/]", "5 x 5");
                table.AddRow("[red]Hard[/]", "8 x 8");
                table.AddRow("Custom", $"? x ?");
            AnsiConsole.Write(table);

            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\n[blue]Select difficulty:[/] ")
                    .AddChoices("[green]Easy[/]", 
                    "[yellow]Medium[/]", 
                    "[red]Hard[/]", 
                    "Custom")
                    );
            
            AnsiConsole.MarkupLine($"\n[blue]Difficulty chosen:[/] {choice}");
            // Green square - U+1F7E9; White square - U+2B1C; Yellow square - U+1F7E8;

            return choice;
        }

        /// <returns>
        /// Returns the custom value of rows. Only called if user inputs the
        /// custom difficulty.
        /// </returns>
        public int RequestRow()
        {
            int rowNum = AnsiConsole.Ask<int>("Number of [blue]rows[/]?");
            while (rowNum <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid value! -- Min. 1[/]");
                rowNum = AnsiConsole.Ask<int>("Number of [blue]rows[/]?");
            }
            
            return rowNum;
        }

        /// <returns>
        /// Returns the custom value of columns. Only called if user inputs the
        /// custom difficulty.
        /// </returns>
        public int RequestColumn()
        {
            int columnNum = AnsiConsole.Ask<int>("Number of [red]columns[/]?");
            while (columnNum <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid value! -- Min. 1[/]");
                columnNum = AnsiConsole.Ask<int>("Number of [red]columns[/]?");
            }

            return columnNum;
        }

        public int RequestTouch()
        {
            var touchNum = AnsiConsole.Ask<int>("Number of [green]touches[/]?");
            if(touchNum == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Really?[/]");
            }

            int touch = touchNum;
            return touch;
        }

        /// <summary>
        /// Method that fakes a loading section.
        /// It's used to give the illusion to the user for the sake of aesthetic,
        /// but also give feedback - allowing the user to be reminded of how many
        /// rows and columns have been selected.
        /// </summary>
        /// <param name="rows">
        /// The number of rows.
        /// </param>
        /// <param name="columns">
        /// The number of columns.
        /// </param>
        public void Load(int rows, int columns)
        {
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots)
                .Start("Processing...", ctx =>
                {
                    Thread.Sleep(1000);
                    ctx.Status($"Rows selected: {rows}");
                    Thread.Sleep(1500);
                    ctx.Status($"Columns selected: {columns}");
                    Thread.Sleep(1500);
                    ctx.Status("Generating...");
                    Thread.Sleep(2000);
                });

            AnsiConsole.MarkupLine("\n[green]Complete![/]");
        }

        /// <summary>
        /// Draws the grid with squares.
        /// </summary>
        /// <param name="size">
        /// Bool that contains the dimensions,
        /// first value is the rows and the second's the columns.
        /// </param>
        /// <returns>
        /// The full grid display.
        /// </returns>
        /// <remarks>
        /// Ai usado para:
        /// saber como ler valores nas grids e
        /// saber como "desenhar" grids
        /// </remarks>
        public void GridDraw(bool[,] size, (int, int) cursor)
        {
            int length = size.GetLength(0); // IA para saber como ler valores
            int width = size.GetLength(1); // das grids

            int cursorX = cursor.Item1;
            int cursorY = cursor.Item2;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string blank = "\u2B1C";
            string cell = char.ConvertFromUtf32(0x1F7E9);
            string icon = char.ConvertFromUtf32(0x1F7E8);

            // IA usado para saber como "desenhar" grids
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (x == cursorX && y == cursorY)
                    {
                        Console.Write(icon + " ");
                    }
                    else if (size[x, y])
                    {
                        Console.Write(cell + " ");
                    }
                    else
                    {
                        Console.Write(blank + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}