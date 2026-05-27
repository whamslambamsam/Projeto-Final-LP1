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
        public string DifficultySelect()
        {
            var table = new Table();
                table.AddColumn("Difficulty");
                table.AddColumn("Size");
                table.AddRow("[green]Easy[/]", "3 x 3");
                table.AddRow("[yellow]Medium[/]", "5 x 5");
                table.AddRow("[red]Hard[/]", "8 x 8");
                table.AddRow("Custom", $"? x ?");
            AnsiConsole.Write(table);

            var choice = AnsiConsole.Prompt(
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

        public int RequestRow()
        {
            var rowNum = AnsiConsole.Ask<int>("Number of [blue]rows[/]?");
            while (rowNum <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid value! -- Min. 1[/]");
                rowNum = AnsiConsole.Ask<int>("Number of [blue]rows[/]?");
            }

            int row = rowNum;
            return row;
        }

        public int RequestColumn()
        {
            var columnNum = AnsiConsole.Ask<int>("Number of [red]columns[/]?");
            while (columnNum <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid value! -- Min. 1[/]");
                columnNum = AnsiConsole.Ask<int>("Number of [red]columns[/]?");
            }

            int column = columnNum;
            return column;
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

        public void GridDraw(bool[,] size)
        {
            int length = size.GetLength(0); // IA para saber como ler valores
            int width = size.GetLength(1); // das grids

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string blank = "\u2B1C";
            string cell = char.ConvertFromUtf32(0x1F7E9);

            Console.WriteLine();

            // IA usado para saber como "desenhar" grids
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (size[x, y])
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