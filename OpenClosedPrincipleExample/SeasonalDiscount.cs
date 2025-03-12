

namespace OpenClosedPrincipleExample
{
    public class SeasonalDiscount : IDiscontStrategy
    {
        public double ApplyDiscount(double amount) => amount * 0.1;
    }
}