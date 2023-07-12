using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

namespace JujaMazes.ConsoleApp
{
    internal class MazeViewer
    {
        public string GetMazeAscii(Maze maze)
        {
            var numCharsInLine = maze.Width * 2 + 1;

            var str = new string(new byte[numCharsInLine].Select(x => '_').ToArray()) + '\n';

            var matrix = maze.GetCellsMatrix();

            for (int i = 0; i < maze.Height; i++)
            {
                var row = new char[numCharsInLine];

                var rIndex = 0;
                row[rIndex++] = matrix[i, 0].LeftWall ? '|' : ' ';
                
                for (int j = 0; j < maze.Width; j++)
                {
                    row[rIndex++] = matrix[i, j].BottomWall ? '_' : ' ';
                    row[rIndex++] = matrix[i, j].RightWall ? '|' : ' ';
                }

                str += new string(row) + '\n';
            }

            return str;
        }
    }
}
