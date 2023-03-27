using Shop.BLL.Dtos;

namespace Shop.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();

        ServiceResult GetById(int Id);
       
    }
}
