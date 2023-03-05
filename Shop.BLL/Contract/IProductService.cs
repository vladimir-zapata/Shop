using Shop.BLL.Core;

namespace Shop.BLL.Contract
{
    public interface IProductService 
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
    }
}
