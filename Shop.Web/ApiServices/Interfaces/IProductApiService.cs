using Shop.Web.Models.Response.Products;
using Shop.Web.ViewModels.Products;
using System.Threading.Tasks;

namespace Shop.Web.ApiServices.Interfaces
{
    public interface IProductApiService
    {
        Task<ProductListResponse> GetProducts();
        Task<ProductResponse> GetProduct(int id);
        Task<ProductResponse> SaveProduct(CreateProductViewModel createProductViewModel);
        Task<ProductResponse> EditProduct(UpdateProductViewModel updateProductViewModel);
        Task<ProductResponse> DeleteProduct(DeleteProductViewModel deleteProductViewModel);
    }
}
