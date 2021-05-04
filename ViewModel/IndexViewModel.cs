using SampleBlog.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleDTO> SliderArticles { get; set; } = new List<ArticleDTO>();
        public IEnumerable<ArticleDTO> BodyArticles { get; set; } = new List<ArticleDTO>();
        public IEnumerable<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
