using JujaMazes.Lib.Models;

namespace JujaMazes.Lib.Utils
{
    public static class MazeExpansion
    {
        public static Cell[,] GetCellsMatrix(this Maze maze)
        {
            if (maze.Cells == null)
                throw new ArgumentNullException(nameof(maze));

            var cells = new Cell[maze.Height, maze.Width];

            var curCellsIndex = 0;

            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    cells[i, j] = maze.Cells[curCellsIndex];
                    curCellsIndex++;
                }
            }

            return cells;
        }
    }
}
