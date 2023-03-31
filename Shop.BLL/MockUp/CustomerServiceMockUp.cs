using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using shop.BLL.Services;


namespace Shop.BLL.MockUp
{


    public class CustomerServiceMockUp
    {
        private readonly ICustomerService customerService;

        public CustomerServiceMockUp(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public ServiceResult GetAll()
        {
            return this.customerService.GetAll();
        }

        public ServiceResult GetById(int Id)
        {
            return this.customerService.GetById(Id);
        }


    }
}
