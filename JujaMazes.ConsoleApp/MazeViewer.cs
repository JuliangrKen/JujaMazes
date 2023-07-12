using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

namespace JujaMazes.ConsoleApp
{
    internal class MazeViewer
    {
        private const char VerticalWall = '|';
        private const char NoVerticalWall = '.';
        private const char HorisontalWall = '_';
        private const char NoHorisontalWall = ' ';

        public string GetMazeAscii(Maze maze)
        {
            var matrix = maze.GetCellsMatrix();

            var str = CreateTopWallInFirstLine(maze, matrix);

            var numCharsInLine = maze.Width * 2 + 1;

            for (int i = 0; i < maze.Height; i++)
            {
                str += CreateLine(maze, matrix, numCharsInLine, i);
            }

            return str;
        }

        private static string CreateTopWallInFirstLine(Maze maze, Cell[,] matrix)
        {
            var str = string.Empty;

            for (int i = 0; i < maze.Height; i++)
            {
                str += NoVerticalWall;
                str += GetHorisontalWallChar(matrix[0, i].TopWall);
            }

            str += NoVerticalWall + "\n";

            return str;
        }

        private static string CreateLine(Maze maze, Cell[,] matrix, int numCharsInLine, int rowIndex)
        {
            var str = string.Empty;

            var row = new char[numCharsInLine];

            var rIndex = 0;
            row[rIndex++] = matrix[rowIndex, 0].LeftWall ? '|' : ' ';

            for (int j = 0; j < maze.Width; j++)
            {
                row[rIndex++] = GetHorisontalWallChar(matrix[rowIndex, j].BottomWall);
                row[rIndex++] = GetVerticalWallChar(matrix[rowIndex, j].RightWall);
            }

            str += new string(row) + '\n';

            return str;
        }

        private static char GetHorisontalWallChar(bool exist)
            => exist ? HorisontalWall : NoHorisontalWall;

        private static char GetVerticalWallChar(bool exist)
            => exist ? VerticalWall : NoVerticalWall;
    }
}
