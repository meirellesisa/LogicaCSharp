using LogicaPedidosEItensDeUmaLoja.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaPedidosEItensDeUmaLoja.Entities
{
    public class Order
    {
        public DateTime Moment {  get; set; }   
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime Moment, OrderStatus Status, Client client)
        {
            this.Moment = Moment;
            this.Status = Status;
            this.Client = client;   
        }
        public void AddItem (OrderItem item)
        {
            Items.Add (item);   
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            var sum = 0.0;
            foreach (var item in Items)
            {
               sum += item.Subtotal(); ;
            }

            return sum;

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyyy hh:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.Date.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");
            foreach(var item in Items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Product.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $ ");
                sb.AppendLine(item.Subtotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            
            return sb.ToString();
        }
        
        
    }
}
