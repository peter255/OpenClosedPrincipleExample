

namespace OpenClosedPrincipleExample
{
    public class LoyaltyDiscount : IDiscontStrategy
    {
        public double ApplyDiscount(double amount) => amount * 0.2;
    }
}