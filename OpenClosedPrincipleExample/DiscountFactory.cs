

namespace OpenClosedPrincipleExample
{
    public static class DiscountFactory
    {
        public static IDiscountStrategy GetDiscountStrategy(string discountType)
        {

            try
            {
                return (IDiscountStrategy)Activator.CreateInstance(Type.GetType($"OpenClosedPrincipleExample.{discountType}Discount"));
            }
            catch
            {
                return new NoDiscount();
            }

        }
    }
}