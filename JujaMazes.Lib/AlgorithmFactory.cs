using JujaMazes.Lib.Algorithms;

namespace JujaMazes.Lib
{
    public class AlgorithmFactory : IAlgorithmFactory
    {
        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }
        public IDecisionMaker DecisionMaker { get; set; } = new DefaultDecisionMaker();

        public IMazeAlgorithm GetAlgorithm(Enums.Algorithms algorithm)
            => algorithm switch
            {
                Enums.Algorithms.Eller => new EllerAlgorithm(MazeWidth, MazeHeight, DecisionMaker),
                _ => throw new NotImplementedException(),
            };
    }
}
