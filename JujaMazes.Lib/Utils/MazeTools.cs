using JujaMazes.Lib.Exceptions;

namespace JujaMazes.Lib.Utils
{
    public static class MazeTools
    {
        public const int MinSize = 2;

        public static bool SizeIsValid(params int[] sizes)
        {
            foreach (int size in sizes)
            {
                if (size < MinSize)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check size correctness and throw exception if need
        /// </summary>
        /// <param name="sizes"></param>
        /// <exception cref="IncorrectMazeSizeException">if size incorrect</exception>
        public static void HandleSize(params int[] sizes)
        {
            if (!SizeIsValid(sizes))
                throw new IncorrectMazeSizeException();
        }
    }
}
