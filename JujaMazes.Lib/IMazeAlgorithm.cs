using JujaMazes.Lib.Models;

namespace JujaMazes.Lib
{
    public interface IMazeAlgorithm
    {
        string AlgorithmName { get; }
        
        int MazeWidth { get; set; }
        int MazeHeight { get; set; }

        Maze? LastMaze { get; }

        Maze GenerateMaze(); 
    }
}
