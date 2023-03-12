using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dto;
using Shop.DAL.Entities;

namespace Shop.BLL.Validations
{
    public class ProductValidation : IProductValidation
    {
        public ServiceResult? ValidateGetProductById(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id == 0 || id < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un id valido";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateProduct(Product product)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(product.ProductName))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (product.UnitPrice == 0 || product.UnitPrice == null)
            {
                result.Success = false;
                result.Message = "El precio es requerido";
                return result;
            }

            if (product.CategoryId == 0 || product.CategoryId == null)
            {
                result.Success = false;
                result.Message = "La categoria es requerida";
                return result;
            }

            if (product.SupplierId == 0 || product.SupplierId == null)
            {
                result.Success = false;
                result.Message = "El suplidor es requerido";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateProductToSave(Product product)
        {
            ServiceResult result = new ServiceResult();

            var isValidProduct = ValidateProduct(product);

            if (isValidProduct != null) return isValidProduct;

            if (product.CreationUser == 0 || product.CreationUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un usuario de solicitud valido";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateProductToUpdate(Product product)
        {
            ServiceResult result = new ServiceResult();

            var isValidProduct = ValidateProduct(product);

            if (isValidProduct != null) return isValidProduct;

            if (product.ProductId == 0 || product.ProductId == null || product.ProductId < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un id de producto valido";
                return result;
            }

            if (product.ModifyUser == 0 || product.ModifyUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un usuario de solicitud valido";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateProductToDelete(DeleteProductDto deleteRequest)
        {
            ServiceResult result = new ServiceResult();

            if (deleteRequest.ProductId == 0 || deleteRequest.ProductId < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un id de producto valido";
                return result;
            }

            if (deleteRequest.RequestUser == 0 || deleteRequest.RequestUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un usuario de solicitud valido";
                return result;
            }

            return null;
        }
    }
}
