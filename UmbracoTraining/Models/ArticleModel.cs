using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace UmbracoTraining.Models
{
    public class ArticleModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public IEnumerable<HttpPostedFileBase> FeaturedImage { get; set; }
        [Required]
        public string ArticleContent { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public string AuthorTitle { get; set; }
    }
}