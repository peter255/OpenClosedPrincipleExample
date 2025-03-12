

namespace OpenClosedPrincipleExample
{
    public class Order
    {
        public double TotalAmount { get; set; }
        private readonly IDiscountStrategy _discontStrategy;
        public Order(IDiscountStrategy discontStrategy)
        {
            _discontStrategy = discontStrategy;
        }
        public double GetDiscount() => _discontStrategy.ApplyDiscount(TotalAmount);
    }
}