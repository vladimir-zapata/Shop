using Shop.BLL.Core;
using Shop.BLL.Dto;
using Shop.DAL.Entities;

namespace Shop.BLL.Contract
{
    public interface IProductValidation
    {
        ServiceResult? ValidateGetProductById(int id);
        ServiceResult? ValidateProduct(Product product);
        ServiceResult? ValidateProductToSave(Product product);
        ServiceResult? ValidateProductToUpdate(Product product);
        ServiceResult? ValidateProductToDelete(DeleteProductDto product);
    }
}
