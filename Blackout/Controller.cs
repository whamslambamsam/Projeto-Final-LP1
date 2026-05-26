using System;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    public class Controller
    {
        private string choice;
        public string Choice
        {
            get {return Choice; } 
            set {choice = Choice; }
        }

        public int GridBuilder(int rows, int columns)
        {
            int RowsNum = rows;
            int ColumnsNum = columns;

            if (Choice == "[green]Easy[/]")
            {
                
            }

            else if (Choice == "[yellow]Medium[/]")
            {
                    
            }

            else if (Choice == "[red]Hard[/]")
            {
                    
            }

            else if (choice == "Custom")
            {
                    
            }
        }
    }
}
