

namespace OpenClosedPrincipleExample
{
    public class NoDiscount : IDiscontStrategy
    {
        public double ApplyDiscount(double amount) => amount;
    }
}