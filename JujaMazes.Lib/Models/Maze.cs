namespace JujaMazes.Lib.Models
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Cell>? Cells { get; set; }
    }
}
