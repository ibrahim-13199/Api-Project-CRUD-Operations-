using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using WepApi.DTO;
using WepApi.Model;
namespace WepApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebDbContext dbContext;

        public ProductRepository(WebDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ProductDTO> GetAllProduct()
        {
             List<Product> productList = dbContext.prouducts.Include(p=>p.categoryRelation).ToList();
             List<ProductDTO> productDTOList = new List<ProductDTO>();
             foreach (Product product in productList)
             {
                ProductDTO productDTO1 = new ProductDTO();
                productDTO1.Id = product.Id;
                productDTO1.Name = product.name;
                productDTO1.Describtion = product.Describtion;
                productDTO1.Price = product.price;
                productDTO1.CategoryName = product.categoryRelation.name;
                productDTOList.Add(productDTO1);
                
              }
            return productDTOList ;
        }

        public ProductDTO GetProductById(int id)
        {
            Product product1 = dbContext.prouducts.Include(c =>c.categoryRelation ).FirstOrDefault(p => p.Id == id);
            ProductDTO productDTO = new ProductDTO();
            productDTO.Id = product1.Id;
            productDTO.Name = product1.name;
            productDTO.Price = product1.price;
            productDTO.Image = product1.Image;
            productDTO.Describtion = product1.Describtion;
            productDTO.CategoryName=product1.categoryRelation.name;
            return (productDTO);
        }

        public int AddProduct(ProductDTO NewProduct)
        {
            if (NewProduct.Name != null)
            {
                Product pro = new Product();

                pro.name = NewProduct.Name;
                pro.price = NewProduct.Price;
                pro.Image = NewProduct.Image;
                pro.Describtion = NewProduct.Describtion;
                
                pro.cat_Id = NewProduct.CatId;

                dbContext.prouducts.Add(pro);
                dbContext.SaveChanges();
            }
            return 0;
        }

        public int editProduct(int id, ProductDTO pro1)
        {
            Product oldProduct = dbContext.prouducts.FirstOrDefault(n => n.Id == id);
            if (oldProduct != null)
            {

                oldProduct.price = pro1.Price;
                oldProduct.name = pro1.Name;
                oldProduct.Describtion = pro1.Describtion;
                oldProduct.Image = pro1.Image;
                oldProduct.cat_Id = pro1.CatId;
                try
                {

                    int rowAffected = dbContext.SaveChanges();
                    return rowAffected;
                }
                catch (Exception)
                {

                   return 0;
                }

            }
            return 0;
        }

        public int Delete(int id)
        {
            Product P1 = dbContext.prouducts.FirstOrDefault(p=>p.Id==id);
            if (P1 == null)
            {
                return -1;
            }

            dbContext.prouducts.Remove(P1);
            int rowRemoved = dbContext.SaveChanges();
            return rowRemoved;

        }

    }
}
