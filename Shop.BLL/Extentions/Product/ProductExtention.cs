using Shop.BLL.Dto;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using System;

namespace Shop.BLL.Extentions
{
    public static class ProductExtention
    {
        public static Product GetProductFromSaveDto(this SaveProductDto savedProduct)
        {
            Product product = new Product()
            {
                ProductName = savedProduct.ProductName,
                UnitPrice = savedProduct.UnitPrice,
                CategoryId = savedProduct.CategoryId,
                SupplierId = savedProduct.SupplierId,
                CreationUser = savedProduct.RequestUser,
                CreationDate = DateTime.Now
            };

            return product;
        }

        public static ProductModel GetProductModelFromProduct(this Product product)
        {
            ProductModel pm = new ProductModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                UnitPrice = product.UnitPrice,
                Discontinued = product.Discontinued
            };

            return pm;
        }
    }
}
