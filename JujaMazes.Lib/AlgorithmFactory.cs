using JujaMazes.Lib.Algorithms;
using JujaMazes.Lib.Enums;

namespace JujaMazes.Lib
{
    public class AlgorithmFactory : IAlgorithmFactory
    {
        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }

        public IMazeAlgorithm GetAlgorithm(Algorithm algorithm)
            => algorithm switch
            {
                Algorithm.Eller => new EllerAlgorithm() { MazeWidth = MazeWidth, MazeHeight = MazeHeight },
                _ => throw new NotImplementedException(),
            };
    }
}
