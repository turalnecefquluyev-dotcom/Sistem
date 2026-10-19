using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repository.Repo
{
    public interface IRepository<T>  where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);

    }
}
