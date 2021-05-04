using Microsoft.AspNetCore.Mvc;
using SampleBlog.Areas.Admin.ViewModel;
using SampleBlog.DAL.Models;
using SampleBlog.DAL.Repositaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IApplicationUserRepository userRepository;

        public UserController(IApplicationUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var vm = new UsersIndexViewModel
            {
                Users = await userRepository.GetAll()
            };
            return View(vm);
        }

        [HttpGet]
        public  IActionResult Add()
        {
            return View(new AddUserViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = new ApplicationUser
            {
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                Email = vm.Email,
                Password = vm.Password,
                ProfilePhotoUrl = vm.UserImageUrl
            };
            await userRepository.Add(user);
            TempData["StatusMessage"] = "New User account created successfully";
            return RedirectToAction(nameof(Add));
        }
    }
}
