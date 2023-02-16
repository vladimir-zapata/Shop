using Shop.DAL.Entities;
using System.Collections.Generic;

namespace Shop.DAL.Interfaces
{
    public interface IProductRepository
    {
        void Save(Product product);
        void Update(Product product);
        void Remove(Product product);
        Product GetById(int id);
        List<Product> GetAll();
        bool Exists(string name);
    }
}
