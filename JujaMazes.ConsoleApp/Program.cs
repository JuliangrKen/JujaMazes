using JujaMazes.ConsoleApp;
using JujaMazes.Lib;
using JujaMazes.Lib.Enums;
using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

//// Используется простейший лабиринт для дебага
//var maze = new Maze()
//{
//    Height = 2,
//    Width = 2,
//    Cells = new List<Cell>()
//    {
//        new Cell() { TopWall = true, LeftWall = false },
//        new Cell() { TopWall = true, LeftWall = false },
//        new Cell() { TopWall = true, LeftWall = false },
//        new Cell() { TopWall = false, LeftWall = true },
//    }
//};

//maze.Normalize();

//Console.WriteLine(new MazeViewer().GetMazeAscii(maze));

var algFactory = new AlgorithmFactory() { MazeHeight = 5, MazeWidth = 5 };
var alg = algFactory.GetAlgorithm(Algorithm.Eller);

Console.WriteLine(new MazeViewer().GetMazeAscii(alg.GenerateMaze()));
