using Sitecore.Feature.Blog.Models;
using Sitecore.Feature.Blog.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Blog.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleController() { }

        public ActionResult List()
        {
            var currentContextItem = Sitecore.Context.Item; // Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;

            List<Sitecore.Data.Items.Item> articleItems = currentContextItem.GetChildren().ToList();
            List<ArticleViewModel> articleViewModelList = new List<ArticleViewModel>();
            foreach (Sitecore.Data.Items.Item articleItem in articleItems)
            {
                ArticleViewModel articleViewModel = new ArticleViewModel()
                {
                    ArticleModel = new ArticleModel() { Title = articleItem.Fields["Title"].Value, Body = articleItem.Fields["Body"].Value, Summary= articleItem.Fields["Summary"].Value },
                    Url = Sitecore.Links.LinkManager.GetItemUrl(articleItem)
                };

                articleViewModelList.Add(articleViewModel);
            }

            var viewModel = new ArticleListViewModel
            {
                ArticleList = articleViewModelList
            };

            return View();
        }

        public ActionResult Display()
        {
            return View();
        }
    }
}