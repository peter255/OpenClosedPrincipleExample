

namespace OpenClosedPrincipleExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool IsContinue = true;
            while (IsContinue)
            {
                Console.WriteLine("Enter Order Total Amount:");
                double totalAmount = double.Parse(Console.ReadLine());

                Console.WriteLine(@"
Discount Types:
- Seasonal
- Loyalty

Enter Discount Type:");
                string discountType = Console.ReadLine();
                IDiscontStrategy discountStrategy = DiscountFactory.GetDiscountStrategy(discountType);

                Order order = new Order(discountStrategy)
                {
                    TotalAmount = totalAmount
                };
                double discount = order.GetDiscount();
                Console.WriteLine($@"
Total Amount: {order.TotalAmount}
Discount: {discount}
Net Amount: {order.TotalAmount - discount}
------------------------------------------");

                Console.WriteLine(@"Do you want to continue? (Y/N)");
                IsContinue = Console.ReadLine().ToUpper() == "Y";
            }
        }
    }
}