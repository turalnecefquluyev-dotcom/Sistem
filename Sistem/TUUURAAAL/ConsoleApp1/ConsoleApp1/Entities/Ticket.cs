using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
