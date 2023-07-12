using JujaMazes.Lib.Enums;
using System.Security.Cryptography;

namespace JujaMazes.Lib
{
    public class DefaultDecisionMaker : IDecisionMaker
    {
        /// <summary>
        /// 50 / 50
        /// </summary>
        public bool Decide(Walls wall)
            => RandomNumberGenerator.GetInt32(1, 101) > 50;
    }
}
