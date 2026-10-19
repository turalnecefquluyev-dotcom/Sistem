using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }

}
