using JujaMazes.Lib.Models;

namespace JujaMazes.Lib
{
    public class MazeBuilder : IMazeBuilder
    {
        public Maze Build(Cell[,] cells)
        {
            var maze = new Maze()
            {
                Height = cells.GetLength(0),
                Width = cells.GetLength(1),
                Cells = new List<Cell>(),
            };

            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    maze.Cells.Add(cells[i, j]);
                }
            }

            return maze;
        }
    }
}
