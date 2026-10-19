using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repository.Repo
{
    internal class OrderItemRepository : IRepository<OrderItem>
    {
        ShopDBContext _contex = new ShopDBContext();
        public void Add(OrderItem entity)
        {
            _contex.Add(entity);
            _contex.SaveChanges();
        }

        public void Delete(int Id)
        {
            var DeleteItemId = _contex.orderItems.FirstOrDefault(x=> x.Id == Id);
            if (DeleteItemId != null)
            {
                _contex.Remove(DeleteItemId);
                _contex.SaveChanges();
            }

        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _contex.orderItems.ToList();
        }

        public OrderItem GetById(int id)
        {
            return _contex.orderItems.FirstOrDefault(c => c.Id == id);
        }

        public void Update(OrderItem entity)
        {
           var UpdateId = _contex.orderItems.FirstOrDefault(c=>c.Id== entity.Id);
            if (UpdateId != null) { 
                 UpdateId.Quatity = entity.Quatity;
                 UpdateId.Price =  entity.Price;
                 UpdateId.OrderId = entity.OrderId;
                 UpdateId.ProductId = entity.ProductId;
                _contex.SaveChanges();
            }
        }
    }
}
