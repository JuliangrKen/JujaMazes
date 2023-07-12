using JujaMazes.ConsoleApp;
using JujaMazes.Lib;
using JujaMazes.Lib.Enums;

var algFactory = new AlgorithmFactory() { MazeHeight = 5, MazeWidth = 5 };
var alg = algFactory.GetAlgorithm(Algorithms.Eller);

Console.WriteLine("Algorithm name: " +  alg.AlgorithmName);
Console.WriteLine(new MazeViewer().GetMazeAscii(alg.GenerateMaze()));
