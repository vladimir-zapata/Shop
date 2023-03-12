using Shop.BLL.Core;
using Shop.BLL.Dto;

namespace Shop.BLL.Contract
{
    public interface IProductService : IBaseService 
    {
        ServiceResult SaveProduct(SaveProductDto product);
        ServiceResult UpdateProduct(UpdateProductDto product);
        ServiceResult DeleteProduct(DeleteProductDto product);
    }
}
