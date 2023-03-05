using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Models;
using Shop.DAL.Interfaces;
using System;
using System.Linq;

namespace Shop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger _logger;

        public ProductService(IProductRepository repository, ILogger<IProductRepository> logger)
        {
            _repository = repository;
            this._logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation("Consultando productos");

                var products = _repository
                                   .GetEntities()
                                   .Where(x => !x.Deleted)
                                   .Select(x => new ProductModel()
                                   {
                                       ProductId = x.ProductId,
                                       ProductName = x.ProductName,
                                       CategoryId = x.CategoryId,
                                       Discontinued = x.Discontinued,
                                       SupplierId = x.SupplierId,
                                       UnitPrice = x.UnitPrice
                                   })
                                   .ToList();

                result.Data = products;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation($"Consultando producto con id {id}");

                var product = _repository.GetEntity(id);

                if (product == null || product.Deleted)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el producto con id {id}";
                }
                else
                {
                    ProductModel productModel = new ProductModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        CategoryId = product.CategoryId,
                        SupplierId = product.SupplierId,
                        UnitPrice = product.UnitPrice,
                        Discontinued = product.Discontinued
                    };

                    result.Data = productModel;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo producto: {id}";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
