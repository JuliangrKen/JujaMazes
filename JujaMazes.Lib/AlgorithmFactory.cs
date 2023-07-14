using JujaMazes.Lib.Algorithms;
using JujaMazes.Lib.Enums;

namespace JujaMazes.Lib
{
    public class AlgorithmFactory : IAlgorithmFactory
    {
        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }
        public IDecisionMaker DecisionMaker { get; set; }

        #region constructors
        public AlgorithmFactory(int mazeWidth, int mazeHeight) : this(mazeWidth, mazeHeight, new DefaultDecisionMaker())
        {
        }

        public AlgorithmFactory(int size, IDecisionMaker decisionMaker) : this(size, size, decisionMaker)
        {
        }

        public AlgorithmFactory(int size) : this(size, size, new DefaultDecisionMaker())
        {
        }

        public AlgorithmFactory(IDecisionMaker decisionMaker) : this(5, 5, decisionMaker)
        {
        }
        #endregion

        public AlgorithmFactory(int mazeWidth, int mazeHeight, IDecisionMaker decisionMaker)
        {
            MazeWidth = mazeWidth;
            MazeHeight = mazeHeight;
            DecisionMaker = decisionMaker;
        }

        public IMazeAlgorithm GetAlgorithm(Algorithm algorithm)
            => algorithm switch
            {
                Algorithm.Eller => new EllerAlgorithm(MazeWidth, MazeHeight, DecisionMaker),
                _ => throw new NotImplementedException(),
            };
    }
}
