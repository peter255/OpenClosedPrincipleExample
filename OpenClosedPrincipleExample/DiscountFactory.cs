

namespace OpenClosedPrincipleExample
{
    public static class DiscountFactory
    {
        public static IDiscontStrategy GetDiscountStrategy(string discountType)
        {

            try
            {
                return (IDiscontStrategy)Activator.CreateInstance(Type.GetType($"OpenClosedPrincipleExample.{discountType}Discount"));
            }
            catch
            {
                return new NoDiscount();
            }

        }
    }
}