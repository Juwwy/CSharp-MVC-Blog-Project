﻿using Microsoft.AspNetCore.Mvc;
using SampleBlog.Areas.Admin.ViewModel;
using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Repositaries;
using SampleBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IApplicationUserRepository applicationUserRepository;

        

        public DashboardController(IArticleRepository articleRepository, ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AdminPanelViewModel
            {

                ArticlesCount = ((IEnumerable<ArticleDTO>) await articleRepository.GetAll()).Count(),
                CategoryCount = ((IEnumerable<CategoryDTO>) await categoryRepository.GetAll()).Count(),
                userCount = ((IEnumerable<ApplicationUserDTO>) await applicationUserRepository.GetAll()).Count(),
              
            };

            return View(vm);
        }
    }
}
