namespace JujaMazes.Lib.Models
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Maze>? Cells { get; set; }
    }
}
