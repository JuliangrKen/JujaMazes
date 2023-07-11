using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

namespace JujaMazes.ConsoleApp
{
    internal class MazeViewer
    {
        /// Временное решение для дебага. Стоит переписать алгоритм.
        public string GetMazeAscii(Maze maze)
        {
            var str = string.Empty;

            var matrix = maze.GetCellsMatrix();

            for(int i = 0; i < maze.Height; i++)
            {
                str += '|';

                for (int j = 0; j < maze.Width; j++)
                {
                    var cell = matrix[i, j];

                    str += cell.BottomWall ? '_' : ' ';
                    str += cell.RightWall ?  '|' : ' ';
                }

                str += '\n';
            }

            return str;
        }
    }
}
