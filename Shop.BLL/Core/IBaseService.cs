namespace Shop.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetBbyID(int id);
    }
}
