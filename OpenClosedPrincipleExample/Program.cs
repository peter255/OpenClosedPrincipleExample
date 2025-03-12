

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
                var implementedClasses = GetListOfDiscountTypes();
                Console.WriteLine("Discount Types:");
                foreach (var type in implementedClasses)
                {
                    Console.WriteLine($"- {type}");
                }

                Console.WriteLine("\nEnter Discount Type:");
                string discountType = Console.ReadLine();
                if (!implementedClasses.Any(x => x == discountType))
                {
                    Console.WriteLine("Invalid Discount Type, please try agin!\n----------------------------");
                    continue;
                }

                Console.WriteLine("Enter Order Total Amount:");
                double totalAmount = double.Parse(Console.ReadLine());
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

        static IEnumerable<string> GetListOfDiscountTypes()
        {
            Type interfaceType = typeof(IDiscountStrategy);
            IEnumerable<string> implementedClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(x => $"{x.Name.Substring(0, x.Name.Length - 8)}");

            return implementedClasses;
        }
    }
}