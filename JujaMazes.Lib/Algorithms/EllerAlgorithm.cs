using JujaMazes.Lib.Exceptions;
using JujaMazes.Lib.Models;
using JujaMazes.Lib.Utils;

namespace JujaMazes.Lib.Algorithms
{
    /// <summary>
    /// http://www.neocomputer.org/projects/eller.html
    /// </summary>
    public class EllerAlgorithm : IMazeAlgorithm
    {
        public string AlgorithmName => "Eller Algorithm";

        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }

        private Maze? maze;
        public Maze? LastMaze => maze;

        private int LastId = 0;

        private readonly Random random = new();
        private readonly IMazeBuilder mazeBuilder = new MazeBuilder();

        /// <summary>
        /// The beginning is strictly in the first cell, 
        /// and the end is in the last, although the Euler algorithm 
        /// itself creates mazes in which there is definitely a passage 
        /// from any point to some other point.
        /// </summary>
        public Maze GenerateMaze()
        {
            if (MazeWidth < 2 || MazeHeight < 2)
                throw new IncorrectMazeSizeException();

            var cells = CreateCells();
            var sets = CreateSets();

            CreateFirstLine(cells, sets);
            CreateOtherLines(cells, sets);
            CreateEndLine(cells, sets);


#if DEBUG 
            for(var i = 0; i < MazeHeight; i++)
            {
                for (var j = 0; j < MazeWidth; j++)
                {
                    Console.Write(' ');
                    Console.Write(sets[i, j]);
                }
                Console.WriteLine();
            }
#endif

            maze = mazeBuilder.Build(cells).Normalize();
            return maze;
        }



        private Cell[,] CreateCells()
        {
            var cells = new Cell[MazeHeight, MazeWidth];

            for (int i = 0; i < MazeHeight; i++)
            {
                for (int j = 0; j < MazeWidth; j++)
                {
                    cells[i, j] = new Cell();
                }
            }

            return cells;
        }

        private void CreateFirstLine(Cell[,] cells, int[,] sets)
        {
            // All cells in the first row have a wall
            for (int i = 0; i < MazeWidth; i++)
                cells[0, i].TopWall = true;

            // The last cell in the row must have a closed right wall
            cells[0, MazeWidth - 1].RightWall = true;

            // Create the first row. No cells will be members of any set
            // -> performed when creating.

            AddWalls(cells, sets, 0);
        }


        private void CreateOtherLines(Cell[,] cells, int[,] sets)
        {
            for (int i = 1; i < MazeHeight - 1; i++)
                AddNextLine(cells, sets, i);
        }

        private void CreateEndLine(Cell[,] cells, int[,] sets)
        {
            var lastIndex = MazeHeight - 1;
            
            AddNextLine(cells, sets, lastIndex);

            for (int i = 0; i < MazeWidth - 1; i++)
            {
                var cell = cells[lastIndex, i];
                
                // Add a bottom wall to every cell
                cell.BottomWall = true;

                // If the current cell and the cell to the right are members of a different set
                if (sets[lastIndex, i] == sets[lastIndex, i + 1])
                {
                    // Remove the right wall
                    cell.RightWall = false;

                    // Union the sets to which the current cell and cell to the right are members.
                    sets[lastIndex, i] = sets[lastIndex, i + 1];
                }
            }

            cells[lastIndex, MazeWidth - 1].BottomWall = true;
        }

        private void AddNextLine(Cell[,] cells, int[,] sets, int row)
        {
            CopySetsToRow(sets, row - 1, row);
            RemoveCellsWithButtomWalls(cells, sets, row);

            AddWalls(cells, sets, row);
        }

        private void AddWalls(Cell[,] cells, int[,] sets, int row)
        {
            // Join any cells not members of a set to their own unique set
            SetUniqueSet(sets, row);
            
            AddRandomRightWalls(cells, sets, row);
            AddRandomBottomWalls(cells, sets, row);
        }

        private void AddRandomRightWalls(Cell[,] cells, int[,] sets, int row)
        {
            for (int i = 0; i < MazeWidth - 1; i++)
            {
                var cell = cells[row, i];

                // If the current cell and the cell to the right are members of the same set,
                // always create a wall between them. (This prevents loops)
                if (sets[row, i] == sets[row, i + 1])
                {
                    cell.RightWall = true;
                    continue;
                }

                //Randomly decide to add a wall or not
                cell.RightWall = ChooseRandomly();

                // If you decide not to add a wall, union the sets to which
                // the current cell and the cell to the right are members
                if (!cell.RightWall)
                {
                    sets[row, i + 1] = sets[row, i];
                    continue;
                }
            }

            // The last cell in the row is necessarily closed
            // if it is not an exit from the maze
            cells[row, MazeWidth - 1].RightWall = true;
        }

        private void AddRandomBottomWalls(Cell[,] cells, int[,] sets, int row)
        {
            for (int i = 0; i < MazeWidth - 1; i++)
            {
                var cell = cells[row, i];

                // TODO:
                // Make sure that each set has at
                // least one cell without a bottom-wall (This prevents isolations)

                if (sets[row, i] != sets[row, i + 1])
                {
                    // If a cell is the only member of its set, do not create a bottom-wall
                    if (i == 0 || sets[row, i] != sets[row, i - 1])
                        continue;

                    // If a cell is the only member of its set without a bottom-wall,
                    // do not create a bottom-wall
                    // TODO: 
                    if (cells[row, i - 1].BottomWall)
                        continue;
                }

                // Randomly decide to add a wall or not.
                cell.BottomWall = ChooseRandomly();
            }
        }

        private int[,] CreateSets()
        {
            return new int[MazeHeight, MazeWidth];
        }

        private void SetUniqueSet(int[,] sets, int row)
        {
            for (int i = 0; i < MazeHeight; i++)
                if (sets[row, i] == 0)
                    sets[row, i] = ++LastId;
        }

        private int[,] CopySetsToRow(int[,] sets, int fromRow, int toRow)
        {
            for (int i = 0; i < MazeWidth; i++)
            {
                sets[toRow, i] = sets[fromRow, i];
            }

            return sets;
        }

        private void RemoveCellsWithButtomWalls(Cell[,] cells, int[,] sets, int row)
        {
            // Remove cells with a bottom-wall from their set
            for (int i = 0; i < MazeWidth; i++)
            {
                if (cells[row - 1, i].BottomWall)
                    sets[row, i] = 0;
                }

        }

        private bool ChooseRandomly()
            => random.Next(1, 100) > 50;
    }
}
