

using System.Reflection;

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

                PrintListOfDiscountTypes();
                string discountType = Console.ReadLine();
                IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategy(discountType);

                Order order = new Order(discountStrategy)
                {
                    TotalAmount = totalAmount
                };
                double discount = order.GetDiscount();

                Console.WriteLine($@"
Total Amount: {order.TotalAmount}
Discount: {discount}
Net Amount: {order.TotalAmount - discount}
------------------------------
Do you want to continue? (Y/N)");

                IsContinue = Console.ReadLine().ToUpper() == "Y";
            }
        }

        static void PrintListOfDiscountTypes()
        {
            Type interfaceType = typeof(IDiscountStrategy);
            List<Type> implementedClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToList();
            Console.WriteLine("\nDiscount Types:");
            foreach (var type in implementedClasses)
            {
                Console.WriteLine($"- {type.Name.Substring(0, type.Name.Length - 8)}");
            }

            Console.WriteLine("\nEnter Discount Type:");
        }
    }
}