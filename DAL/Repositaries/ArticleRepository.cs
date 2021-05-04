using Microsoft.EntityFrameworkCore;
using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositaries
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogDbContext dbContext;

        public ArticleRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Add(Article article)
        {
            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ArticleDTO> Find(int id)
        {
            return await dbContext.Articles.Where(d => d.Id == id).Include(a => a.Category).Include(a => a.Author).Select(a=> new ArticleDTO
            {
                Id= a.Id,
                Title = a.Title,
                Body = a.Body,
                Category = a.Category.CategoryName, 
                Author = $"{a.Author.Firstname} {a.Author.Lastname}",
                AuthorImgUrl = a.Author.ProfilePhotoUrl,
                ArticleImageUrl = a.ArticleImageUrl
            }
            ).FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<Article>> GetAll()
        //{
        //    return await dbContext.Articles.ToListAsync();
        //}

        public async Task<IEnumerable<ArticleDTO>> GetAll(int num= 20)
        {
            return await dbContext.Articles.Include(a => a.Category).Include(a => a.Author).Select(a => new ArticleDTO
            {
                Id = a.Id,
                Title = a.Title,
                Body = a.Body,
                Category = a.Category.CategoryName,
                Author = $"{a.Author.Firstname} {a.Author.Lastname}",
                ArticleImageUrl = a.ArticleImageUrl
            }
            ).Take(num).ToListAsync();
        }

        public async Task<Article> Remove(int id)
        {
            Article post = await dbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);
            dbContext.Articles.Remove(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        //public async Task<Category> GetterCategory(string name)
        //{
        //    return await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);
        //}

        //public async Task<ApplicationUser> GetterUser(string name)
        //{
        //    return await dbContext.ApplicationUsers.FirstOrDefaultAsync(c => c.Firstname == name);
        //}
    }
}
