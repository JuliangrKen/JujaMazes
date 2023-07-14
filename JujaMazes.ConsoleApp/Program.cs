using JujaMazes.ConsoleApp;
using JujaMazes.Lib;
using JujaMazes.Lib.Enums;

var algFactory = new AlgorithmFactory(10);
var alg = algFactory.GetAlgorithm(Algorithm.Eller);

Console.WriteLine("Algorithm name: " +  alg.AlgorithmName);
Console.WriteLine(new MazeViewer().GetMazeAscii(alg.GenerateMaze()));
