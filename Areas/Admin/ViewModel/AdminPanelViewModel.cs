using SampleBlog.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.ViewModel
{
    public class AdminPanelViewModel
    {
        public int ArticlesCount { get; set; } = 0;
        public int CategoryCount { get; set; } = 0;
        public int userCount { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
