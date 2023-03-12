using Shop.BLL.Dto;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using System;

namespace Shop.BLL.Extentions
{
    public static class ProductExtention
    {
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

        public static Product GetProductFromSaveProductDto(this SaveProductDto savedProduct)
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

        public static Product GetProductFromUpdateProductDto(this UpdateProductDto updatedProduct)
        {
            Product product = new Product()
            {
                ProductId= updatedProduct.ProductId,
                ProductName = updatedProduct.ProductName,
                UnitPrice = updatedProduct.UnitPrice,
                CategoryId = updatedProduct.CategoryId,
                SupplierId = updatedProduct.SupplierId,
                ModifyUser = updatedProduct.RequestUser,
                ModifyDate = DateTime.Now,
                Discontinued = updatedProduct.Discontinued
            };

            return product;
        }
    }
}
