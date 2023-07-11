using JujaMazes.Lib.Models;

namespace JujaMazes.Lib
{
    public interface IMazeAlgorithm
    {
        string AlgorithmName { get; }
        Maze GenerateMaze(int weight, int height); 
    }
}
