using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoTraining.Models;
using Umbraco.Web.PublishedModels;
using Umbraco.Core.Services;
using Umbraco.Core;

namespace UmbracoTraining.Controllers
{
    public class ArticleFormController : SurfaceController
    {
        // GET: ArticleForm
        public ActionResult Render()
        {
            var articleModel = new ArticleModel();
            return PartialView("ArticleForm", articleModel);
        }

        [HttpPost]
        [ValidateUmbracoFormRouteString]
        public ActionResult Submit(ArticleModel model)
        {
            var contentService = Services.ContentService;

            var mediaService = Services.MediaService;

            var parentId = new Guid("938d11b8-e150-4f01-8caf-5d8c231350d1");

            var article = contentService.Create(model.Name, parentId, "article");

            article.SetValue("summary", model.Summary);
            article.SetValue("articleContent", model.ArticleContent);
            article.SetValue("authorName", model.AuthorName);
            article.SetValue("authorTitle", model.AuthorTitle);

            var folder = mediaService.CreateMedia(model.Name, -1, "folder");
            
            mediaService.Save(folder);
            
            foreach (var file in model.FeaturedImage)
            {
                var image = mediaService.CreateMedia(file.FileName, folder.Id, "image");

                image.SetValue(Services.ContentTypeBaseServices, "umbracoFile", file.FileName, file.InputStream);
                mediaService.Save(image);

                article.SetValue("featuredImage", image.GetUdi());
            }

            contentService.SaveAndPublish(article);
            return RedirectToCurrentUmbracoPage();
        }
    }
}