using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dto;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Linq;
using Shop.BLL.Extentions;
using Shop.DAL.Exceptions;

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
                                   .Select(x => x.GetProductModelFromProduct())
                                   .ToList();

                result.Data = products;
            }
            catch (ProductDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
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

                Product product = _repository.GetEntity(id);

                if (product == null || product.Deleted)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el producto con id {id}";
                }
                else
                {
                    var productModel = product.GetProductModelFromProduct();

                    result.Data = productModel;
                }
            }
            catch (ProductDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo producto: {id}";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveProduct(SaveProductDto savedProduct)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Product product = savedProduct.GetProductFromSaveDto();

                this._repository.Save(product);
                result.Success = true;
                result.Message = "El producto ha sido añadido correctamente";
            }
            catch (ProductDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando el producto";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateProduct(UpdateProductDto updatedProduct)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Product product = _repository.GetEntity(updatedProduct.ProductId);

                product.ProductName = updatedProduct.ProductName;
                product.UnitPrice = updatedProduct.UnitPrice;
                product.CategoryId = updatedProduct.CategoryId;
                product.SupplierId = updatedProduct.SupplierId;
                product.ModifyUser = updatedProduct.RequestUser;
                product.ModifyDate = DateTime.Now;

                this._repository.Update(product);
                result.Success = true;
                result.Message = "El producto ha sido modificado correctamente";
            }
            catch (ProductDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el producto";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult DeleteProduct(DeleteProductDto deleteProduct)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Product product = _repository.GetEntity(deleteProduct.ProductId);

                product.DeleteUser = deleteProduct.RequestUser;
                product.DeleteDate = DateTime.Now;
                product.Deleted= true;

                this._repository.Update(product);

                result.Success = true;
                result.Message = "El producto ha sido eliminado correctamente";
            }
            catch (ProductDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando el producto";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
