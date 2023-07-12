using JujaMazes.Lib.Enums;

namespace JujaMazes.Lib
{
    public interface IDecisionMaker
    {
        bool Decide(Wall wall);
    }
}
