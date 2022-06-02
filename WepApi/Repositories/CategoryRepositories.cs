using Shared;
using WepApi.DTO;
using WepApi.Model;

namespace WepApi.Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        WebDbContext dbContext;
        public CategoryRepositories(WebDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return dbContext.categories.ToList();
        }
        public CategoryDTO GetById(int id)
        {
            Category category = dbContext.categories.FirstOrDefault(c => c.Id == id);
            CategoryDTO categoryDto = new CategoryDTO();

            categoryDto.Id = id;
            categoryDto.name = category.name;
            categoryDto.Describtion = category.Describtion;

            return categoryDto;
        }

        public int InsertNewCategory(CategoryDTO newCategory)
        {
            Category category1= new Category();
            if (newCategory.name != null) {
             category1.Describtion= newCategory.Describtion;
             category1.name = newCategory.name;
             dbContext.categories.Add(category1);
            dbContext.SaveChanges();
            }
            return 0;

        }

        public int editCategory(int id, CategoryDTO categoryDto)
        {
            Category category1 = dbContext.categories.FirstOrDefault(c => c.Id == id);
            if (category1.name != null)
            {
                category1.name = categoryDto.name;
                category1.Describtion  = categoryDto.Describtion;
                dbContext.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Category category1 = dbContext.categories.FirstOrDefault(p => p.Id == id);
            if (category1 == null)
            {
                return -1;
            }

            dbContext.categories.Remove(category1);
            int rowRemoved = dbContext.SaveChanges();
            return rowRemoved;

        }
    }
}
