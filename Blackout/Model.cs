using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    public class Model
    {
        /// <summary>
        /// Method that forms the grid's "blueprint", so to speak.
        /// </summary>
        /// <param name="length">
        /// The number of rows.
        /// </param>
        /// <param name="width">
        /// The number of columns.
        /// </param>
        /// <returns>
        /// The grid's template.
        /// </returns>
        /// <remarks>
        /// Foi usado AI para perceber como é que poderi-se fazer as grids.
        /// (Estes remarks são para depois ser apagados e em vez postos no
        /// relatório, apenas escrevi no código para não se esqueçer)
        /// </remarks>
        public bool[,] GridSize(int length, int width)
        {
            bool[,] grid = new bool[length, width];
            return grid;
        }
    }
}