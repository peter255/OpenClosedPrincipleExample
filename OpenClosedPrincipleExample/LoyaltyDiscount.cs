

namespace OpenClosedPrincipleExample
{
    public class LoyaltyDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) => amount * 0.2;
    }
}