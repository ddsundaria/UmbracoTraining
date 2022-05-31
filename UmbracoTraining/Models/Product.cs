using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
namespace UmbracoTraining.Models
{
    public class ProductContentModel : ContentModel
    {
        public ProductContentModel(IPublishedContent content) : base(content)
        {
        }

        public double GSTPrice { get; set; }
    }
}