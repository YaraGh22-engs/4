using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Shopping_Cart.Data;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        

        public CategoryServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Category> GetAll()
        {
            var items = _dbContext.categories.AsNoTracking().ToList();
            return items;
        }
        public Category GetById(int categoryId)
        {
            var item = _dbContext.categories.Find(categoryId);
            return item;
        }
        
        public int Create(Category category)
        {
            
                _dbContext.categories.Add(category);
            return _dbContext.SaveChanges();
        }

        //public void Update(Category category)
        //{
        //    //var old_category = _dbContext.categories.FirstOrDefault(c => c.Id == category.Id);
        //    //_dbContext.Entry(old_category).State = EntityState.Detached;

        //    _dbContext.categories.Update(category);
        //    _dbContext.SaveChanges();
        //}
        public int Delete(int Id)
        {
            var category = _dbContext.categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                
                _dbContext.categories.Remove(category);
                return _dbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
            
        }

        
    }
}
