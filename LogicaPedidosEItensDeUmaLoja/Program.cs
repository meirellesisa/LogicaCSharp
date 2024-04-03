using LogicaPedidosEItensDeUmaLoja.Entities;
using LogicaPedidosEItensDeUmaLoja.Entities.Enums;

namespace LogicaPedidosEItensDeUmaLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Isabella!");

            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Birth date: ");
            var birthday = DateTime.Parse(Console.ReadLine());

            var client = new Client(name, email, birthday);

            Console.WriteLine("Enter order date: ");
            Console.Write("Status: ");
            var status = Enum.Parse<OrderStatus>(Console.ReadLine());

            var order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            var quantityItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantityItems ; i++)
            {
                Console.Write("Product name: ");
                var productName = Console.ReadLine();

                Console.Write("Product price: ");
                var productPrice = double.Parse(Console.ReadLine());

                var product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                var ItensQuantity = int.Parse(Console.ReadLine());

                var iten = new OrderItem(ItensQuantity, productPrice, product);
                order.AddItem(iten);

                
            }
            
            Console.WriteLine(order.ToString());

        }
    }
}
