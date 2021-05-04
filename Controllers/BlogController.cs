
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleBlog.DAL.Repositaries;
using SampleBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IArticleRepository articleRepository;

        public BlogController(ICategoryRepository categoryRepository, IArticleRepository articleRepository)
        {
            this.categoryRepository = categoryRepository;
            this.articleRepository = articleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await articleRepository.GetAll(10);
            var categories = await categoryRepository.GetAll();

            var vm = new IndexViewModel
            {
                SliderArticles = articles.Take(2),
                BodyArticles = articles.Take(8).Skip(2),
                Categories = categories 
            };
            return View(vm);
        }

        //Get: /blog/article/{id}
        public async Task<IActionResult> Article(int id)
        {
            if(id != 0)
            {
                var article = await articleRepository.Find(id);
                return View(article);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Photo()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        

       
    }
}
