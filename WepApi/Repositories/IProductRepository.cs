using Shared;
using WepApi.DTO;

namespace WepApi.Repositories
{
    public interface IProductRepository
    {
        int Delete(int id);
        int editProduct(int id, ProductDTO pro1);
        List<ProductDTO> GetAllProduct();
        ProductDTO GetProductById(int id);
        int AddProduct(ProductDTO product1);
    }
}