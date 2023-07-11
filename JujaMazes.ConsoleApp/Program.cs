using JujaMazes.ConsoleApp;
using JujaMazes.Lib.Models;

// Используется простейший лабиринт для дебага
var maze = new Maze()
{
    Height = 2,
    Width = 2,
    Cells = new List<Cell>()
    {
        new Cell() { BottomWall = false, RightWall = false },
        new Cell() { BottomWall = true, RightWall = true },
        new Cell() { BottomWall = true, RightWall = false },
        new Cell() { BottomWall = false, RightWall = true },
    }
};

Console.WriteLine(new MazeViewer().GetMazeAscii(maze));
