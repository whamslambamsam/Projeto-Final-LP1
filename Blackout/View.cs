using System;
using Spectre.Console;

namespace Blackout
{
    public class View
    {
        public void DifficultySelect()
        {
            var table = new Table();
                table.AddColumn("Difficulty");
                table.AddColumn("Size");
                table.AddRow("[green]Easy[/]", "3 x 3");
                table.AddRow("[yellow]Medium[/]", "5 x 5");
                table.AddRow("[red]Hard[/]", "8 x 8");
                table.AddRow("Custom", "? x ?");
            AnsiConsole.Write(table);

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Select difficulty:[/] ")
                    .AddChoices("[green]Easy[/]", "[yellow]Medium[/]", 
                    "[red]Hard[/]", "Custom")
                    );
            
            AnsiConsole.MarkupLine($"[blue]Difficulty chosen:[/] {choice}");
        }
    }
}