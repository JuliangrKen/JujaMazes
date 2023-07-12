using JujaMazes.Lib.Models;

namespace JujaMazes.Lib
{
    public interface IMazeBuilder
    {
        Maze Build(Cell[,] cells);
    }
}
