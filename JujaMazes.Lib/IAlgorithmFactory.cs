namespace JujaMazes.Lib
{
    public interface IAlgorithmFactory
    {
        int MazeWidth { get; set; }
        int MazeHeight { get; set; }
        IMazeAlgorithm GetAlgorithm(Enums.Algorithms algorithm);
    }
}
