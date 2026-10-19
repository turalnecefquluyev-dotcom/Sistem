using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Repository.Repo
{
    internal class TicketRepository : IRepository<Ticket>
    {
        ShopDBContext _contex = new ShopDBContext();

        public void Add(Ticket entity)
        {
            _contex.Add(entity);
            _contex.SaveChanges();
        }

        public void Delete(int Id)
        {
            var ticket = _contex.tickets.FirstOrDefault(c => c.Id == Id);
            if (ticket != null)
            {
                _contex.tickets.Remove(ticket);
                _contex.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _contex.tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return _contex.tickets.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Ticket entity)
        {
            var updateId = _contex.tickets.FirstOrDefault(c => c.Id == entity.Id);
            if (updateId != null)
            {
                updateId.Name = entity.Name;
                updateId.Price = entity.Price;
                updateId.Stock = entity.Stock;
                _contex.SaveChanges();
            }
        }
    }
}