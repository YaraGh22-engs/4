using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int categoryId);
        int Create(Category category);
        //void Update(Category category);
        int Delete(int Id);
        

    }
}
