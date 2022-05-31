using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoTraining.Models;
namespace UmbracoTraining.App_Code
{
    public class ProductController : RenderMvcController
    {
        // GET: Product
        public ActionResult Index(ContentModel model)
        {
            ProductContentModel productModel = new ProductContentModel(model.Content);

            double productPrice = 0;
            double.TryParse(productModel.Content.GetProperty("productPrice").GetValue().ToString(), out productPrice);

            productModel.GSTPrice = productPrice + (productPrice * 0.12);

            return CurrentTemplate(productModel);
        }
    }
}