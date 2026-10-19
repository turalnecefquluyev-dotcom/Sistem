using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repository.Repo
{
    internal class OrderRepository : IRepository<Order>
    {
        private readonly ShopDBContext _context = new ShopDBContext();
        public void Add(Order entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll() 
        {
            return _context.orders.ToList();
        }
        void IRepository<Order>.Delete(int Id)
        {
            var DeleteItemID =  _context.orders.FirstOrDefault(c=> c.Id == Id);
            if(DeleteItemID != null)
            {
                _context.Remove(Id);
                _context.SaveChanges();
            }
        }

        Order IRepository<Order>.GetById(int id)
        {
            return _context.orders.FirstOrDefault(c=>c.Id == id);
        }

        public void Update(Order entity)
        {
            var UpdateID =_context.orders.FirstOrDefault(c=> c.Id == entity.Id);
            if(UpdateID != null)
            {
                UpdateID.CustomerName = entity.CustomerName;
                UpdateID.CreatedTime = entity.CreatedTime;
                _context.SaveChanges();
            }
        }
        
    }
}
