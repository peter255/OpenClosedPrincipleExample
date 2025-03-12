

namespace OpenClosedPrincipleExample
{
    public class Order
    {
        public double TotalAmount { get; set; }
        private readonly IDiscontStrategy _discontStrategy;
        public Order(IDiscontStrategy discontStrategy)
        {
            _discontStrategy = discontStrategy;
        }
        public double GetDiscount() => _discontStrategy.ApplyDiscount(TotalAmount);
    }
}