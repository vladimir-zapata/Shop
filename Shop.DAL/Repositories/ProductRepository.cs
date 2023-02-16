using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger _logger;

        public ProductRepository(ProductContext productContext, ILogger<IProductRepository> logger)
        {
            this._productContext = productContext;
            this._logger = logger;
        }

        public void Save(Product product)
        {
            try 
            {
                Product productToAdd = new Product()
                {
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    UnitPrice = product.UnitPrice,
                    Discontinued = product.Discontinued,
                    CreationDate = DateTime.Now,
                    CreationUser = product.CreationUser
                };

                this._productContext.Products?.Add(productToAdd);
                this._productContext.SaveChanges();

            } catch(Exception ex) 
            {
                this._logger.LogError($"Error adding product", ex.ToString());
            }
        }
        public void Update(Product product)
        {
            try 
            {
                Product productToUpdate = this.GetById(product.ProductId);

                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.SupplierId= product.SupplierId;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.Discontinued = product.Discontinued;
                productToUpdate.ModifyDate = DateTime.Now;
                productToUpdate.ModifyUser = product.ModifyUser;
                this._productContext.SaveChanges();


            } catch(Exception ex) 
            {
                this._logger.LogError($"Error updating product", ex.ToString());
            }
        }
        public void Remove(Product product)
        {
            try
            { 
                Product productToRemove = this.GetById(product.ProductId);

                productToRemove.DeleteDate = DateTime.Now;
                productToRemove.DeleteUser = product.DeleteUser;
                productToRemove.Deleted= true;
                productToRemove.Discontinued = true;

                this.Update(productToRemove);
                this._productContext.SaveChanges();

            } catch(Exception ex)
            {
                this._logger.LogError($"Error removing product", ex.ToString());
            }
        }
        public Product GetById(int id)
        {
            return _productContext.Products!.Find(id);
        }
        public List<Product> GetAll()
        {
            return this._productContext.Products.ToList();
        }
        public bool Exists(string name)
        {
            return this._productContext.Products.Any(pro => pro.ProductName == name);
        }
    }
}
