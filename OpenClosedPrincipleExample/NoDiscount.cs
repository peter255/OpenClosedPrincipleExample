

namespace OpenClosedPrincipleExample
{
    public class NoDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) => amount;
    }
}