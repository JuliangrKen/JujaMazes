using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

namespace JujaMazes.ConsoleApp
{
    internal class MazeViewer
    {
        public string GetMazeAscii(Maze maze)
        {
            var matrix = maze.GetCellsMatrix();

            var str = CreateTopWallInFirstLine(maze, matrix);

            var numCharsInLine = maze.Width * 2 + 1;

            for (int i = 0; i < maze.Height - 1; i++)
            {
                str += CreateLine(maze, matrix, numCharsInLine, i);
            }

            str += CreateLine(maze, matrix, numCharsInLine, maze.Height - 1, '_');

            return str;
        }

        private string CreateTopWallInFirstLine(Maze maze, Cell[,] matrix)
        {
            var str = string.Empty;

            for (int i = 0; i < maze.Height; i++)
            {
                str += '_';
                str += matrix[0, i].TopWall ? '_' : ' ';
            }

            str += "_\n";

            return str;
        }

        private string CreateLine(Maze maze, Cell[,] matrix, int numCharsInLine, int rowIndex, char rWallDefault = ' ')
        {
            var str = string.Empty;

            var row = new char[numCharsInLine];

            var rIndex = 0;
            row[rIndex++] = matrix[rowIndex, 0].LeftWall ? '|' : ' ';

            for (int j = 0; j < maze.Width; j++)
            {
                row[rIndex++] = matrix[rowIndex, j].BottomWall ? '_' : ' ';
                row[rIndex++] = matrix[rowIndex, j].RightWall ? '|' : rWallDefault;
            }

            str += new string(row) + '\n';

            return str;
        }
    }
}
