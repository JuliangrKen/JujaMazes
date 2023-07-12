using JujaMazes.Lib.Models;

namespace JujaMazes.Lib.Utils
{
    public static class MazeExpansion
    {
        /// <summary>
        /// Creates a convenient matrix.
        /// It can be useful for visualization and other things.
        /// </summary>
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

        /// <summary>
        /// Ensures that the cells will match each other.
        /// Priority for the presence of a wall!
        /// </summary>
        public static Maze Normalize(this Maze maze, bool vertical = true, bool horizontal = true)
        {
            var matrix = maze.GetCellsMatrix();

            // Tops & bottoms:
            if (vertical)
                NormalizeVertical(matrix);

            // Lefts & rights:
            if (horizontal)
                NormalizeHorizontal(matrix);

            // Apply:
            maze.Cells = new MazeBuilder().Build(matrix).Cells;

            return maze;
        }

        public static Maze NormalizeVertical(this Maze maze)
            => Normalize(maze, true, false);

        public static Maze NormalizeHorizontal(this Maze maze)
            => Normalize(maze, false, true);

        private static void NormalizeVertical(Cell[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    var cellUp = matrix[j - 1, i];
                    var cellDown = matrix[j, i];

                    if (cellUp.BottomWall != cellDown.TopWall)
                    {
                        cellUp.BottomWall = true;
                        cellDown.TopWall = true;
                    }
                }
            }
        }

        private static void NormalizeHorizontal(Cell[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    var cellLeft = matrix[i, j - 1];
                    var cellRight = matrix[i, j];

                    if (cellLeft.RightWall != cellRight.LeftWall)
                    {
                        cellLeft.RightWall = true;
                        cellRight.LeftWall = true;
                    }
                }
            }
        }
    }
}
