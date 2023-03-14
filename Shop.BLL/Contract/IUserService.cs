using Shop.BLL.Core;
using Shop.BLL.Dtos;

namespace Shop.BLL.Contract
{
     public interface IUserService : IBaseService
    {
        ServiceResult SaveUser(UserAddDtos userAddDtos);
        ServiceResult UpdateUser(UserUpdateDtos userUpdateDtos);
        ServiceResult RemoveUser(UserRemoveDtos userRemoveDtos);

    }
}
