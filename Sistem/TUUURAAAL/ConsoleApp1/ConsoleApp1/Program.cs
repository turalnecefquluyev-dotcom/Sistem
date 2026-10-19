using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using ConsoleApp1.Repository.Repo;
using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TicketRepository ticketRepo = new TicketRepository();
            OrderRepository orderRepository = new OrderRepository();
            OrderItemRepository orderItem = new OrderItemRepository();


            Console.WriteLine(" ORDER ƏMƏLİYYATLARI ");
            Order newOrder = new Order
            {
                CustomerName = "Elcan Şirinov",
                CreatedTime = DateTime.Now
            };
            orderRepository.Add(newOrder);
            Console.WriteLine("Sifariş əlavə olundu.");

            var lastOrder = orderRepository.GetAll().Last();
            lastOrder.CustomerName = "Arzeman Mustafayev (Yeniləndi)";
            orderRepository.Update(lastOrder);
            Console.WriteLine("Sifariş yeniləndi.");

            var orders = orderRepository.GetAll();
            foreach (var o in orders)
            {
                Console.WriteLine($"ID: {o.Id} | Müştəri: {o.CustomerName}");
            }
            Console.WriteLine();


            Console.WriteLine(" ORDER ITEM ƏMƏLİYYATLARI");
            OrderItem newItem = new OrderItem
            {
                Quatity = 3,
                Price = 45.5m,
                OrderId = 1,
                ProductId = 1
            };
            orderItem.Add(newItem);
            Console.WriteLine("Sifariş məhsulu əlavə olundu.");

            var foundItem = orderItem.GetById(1);
            if (foundItem != null)
            {
                Console.WriteLine($"Tapılan məhsul miqdarı: {foundItem.Quatity}");
            }
            Console.WriteLine();


            Console.WriteLine(" TICKET ƏMƏLİYYATLARI ");
            Ticket newTicket = new Ticket
            {
                Name = "Konsert Bileti",
                Price = 30.0m,
                Stock = 50
            };
            ticketRepo.Add(newTicket);
            Console.WriteLine("Bilet əlavə olundu.");

            var allTickets = ticketRepo.GetAll();
            foreach (var t in allTickets)
            {
                Console.WriteLine($"Bilet: {t.Name} | Qiymət: {t.Price} AZN");
            }

            Console.WriteLine("\nBütün əməliyyatlar uğurla başa çatdı!");
            Console.ReadKey();
        }
    }
}