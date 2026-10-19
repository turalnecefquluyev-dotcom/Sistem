using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Ticket Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
