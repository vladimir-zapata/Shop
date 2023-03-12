using Shop.BLL.Dto;
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

        public static Product GetProductFromUpdateDto(this UpdateProductDto updatedProduct)
        {
            Product product = new Product()
            {
                ProductId = updatedProduct.ProductId,
                ProductName = updatedProduct.ProductName,
                UnitPrice = updatedProduct.UnitPrice,
                CategoryId = updatedProduct.CategoryId,
                SupplierId = updatedProduct.SupplierId,
                ModifyUser = updatedProduct.RequestUser,
                ModifyDate = DateTime.Now
            };

            return product;
        }
    }
}
