using Shared;
using WepApi.DTO;

namespace WepApi.Repositories
{
    public interface ICategoryRepositories
    {
        List<Category> GetAll();
        CategoryDTO GetById(int id);
        int InsertNewCategory(CategoryDTO newCategory);
        int Delete(int id);
        int editCategory(int id, CategoryDTO categoryDto);
    }
}