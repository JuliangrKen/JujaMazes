using JujaMazes.Lib.Enums;

namespace JujaMazes.Lib
{
    public interface IMazeFactory
    {
        IMazeAlgorithm GetAlgorithm(Algorithm algorithm);
    }
}
