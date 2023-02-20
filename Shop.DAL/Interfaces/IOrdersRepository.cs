using Shop.DAL.Entities;
using System.Collections.Generic;

namespace Shop.DAL.Interfaces
{
    public interface IOrdersRepository
    {
        void Save(Orders orders);
        void Update(Orders orders);
        void Remove(Orders orders);
        List<Orders> GetAll();
        Orders GetbyId(int orderID);
        bool Exists(string shipname);
    }
}
