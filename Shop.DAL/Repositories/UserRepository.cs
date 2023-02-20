using Shop.DAL.Entities;
using System.Collections.Generic;
using Shop.DAL.Context;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace Shop.DAL.Repositories
{
    public class UserRepository : Interfaces.IUserRepository
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<UserRepository> logger;

        public UserRepository(ShopContext shopContext,
                                ILogger<UserRepository> logger)
        {
            this.shopContext = shopContext;
            this.logger = logger;
        }
        public bool Exists(string name)
        {
            return this.shopContext.Users.Any(st => st.Name == name);
        }
        public List<User> GetAll()
        {
            return this.shopContext.Users.Where(x => !x.Deleted).ToList();
        }

        public User GetById(int userId)
        {
            return this.shopContext.Users!.Find(userId);
        }

        public void Remove(User user)
        {
            try
            {
                User userToRemove = this.GetById(user.UserId);

                userToRemove.Deleted = true;
                userToRemove.DeleteDate = DateTime.Now;
                userToRemove.DeleteUser = user.DeleteUser;

                this.shopContext.Users!.Update(userToRemove);
                this.shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"error removiendo el usuario", ex.ToString());
            }
        }

        public void Save(User user)
        {
            try
            {
                User userToAdd = new User()
                {
                    Email = user.Email,
                    Password = user.Password,
                    Name = user.Name,
                    CreationUser = user.CreationUser,
                    CreationDate = DateTime.Now,
                };
                this.shopContext.Users!.Add(userToAdd);
                this.shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"error removiendo el usuario", ex.ToString());
                throw;
            }
        }

        public void Update(User user)
        {
            try
            {
                User userToUpdate = this.GetById(user.UserId);

                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                userToUpdate.Name = user.Name;
                userToUpdate.ModifyDate= DateTime.Now;
                userToUpdate.ModifyUser = user.ModifyUser;

                this.shopContext.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"error removiendo el usuario", ex.ToString());
            }
        }
    }
}
