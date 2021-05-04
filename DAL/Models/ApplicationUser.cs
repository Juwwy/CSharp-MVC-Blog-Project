using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string Password { get; set; }
        //public string UserName { get; set; }
        public ICollection<Article> Articles { get; set; }

        //public override string ToString()
        //{
        //    return $"{UserName}";
        //}
    }
}
