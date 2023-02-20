using Shop.DAL.Entities;
using System.Collections.Generic;

namespace Shop.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        void Remove(User user);
        User GetById(int user);
        List<User> GetAll();
        bool Exists(string name);
    }
}