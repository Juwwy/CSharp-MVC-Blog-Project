using Microsoft.EntityFrameworkCore;
using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositaries
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext dbContext;

        public CategoryRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Add(Category category)
        {
            if(!await CheckDuplicate(category.CategoryName))
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();

                return true;
            } return false;
        }

        public async Task<CategoryDTO> Find(int id)
        {
            return await dbContext.Categories.Where(c => c.Id == id).Include(c => c.Article).Select(c => new CategoryDTO { Id= c.Id, CategoryName = c.CategoryName, Description = c.Description, NumberOfArticle = c.Article.Count }).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return await dbContext.Categories.Include(c=> c.Article).Select(c=> new CategoryDTO
            {
               Id =c.Id, CategoryName = c.CategoryName, Description = c.Description, NumberOfArticle = c.Article.Count
            }).ToListAsync();
        }

        public async Task<Category> Remove(int id)
        {
            Category category = await dbContext.Categories.FirstOrDefaultAsync(c=> c.Id == id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
        private async Task<bool> CheckDuplicate(string categoryName)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

            if (category != null)
                return true;

            return false;
        }
    }
}
