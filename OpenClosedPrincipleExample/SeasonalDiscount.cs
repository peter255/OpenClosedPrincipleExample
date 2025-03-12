

namespace OpenClosedPrincipleExample
{
    public class SeasonalDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) => amount * 0.1;
    }
}