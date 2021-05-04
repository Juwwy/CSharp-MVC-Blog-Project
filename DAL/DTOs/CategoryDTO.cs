using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int NumberOfArticle { get; set; }
        public string CategoryImgUrl { get; set; } = "https://picsum.photos/300";
    }
}
