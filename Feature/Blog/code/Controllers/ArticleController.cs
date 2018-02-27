using Sitecore.Feature.Blog.Models;
using Sitecore.Feature.Blog.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Diagnostics;

namespace Sitecore.Feature.Blog.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleController() { }

        public ActionResult List()
        {
            var currentContextItem = Sitecore.Context.Item; 

            List<Sitecore.Data.Items.Item> articleItems = currentContextItem.GetChildren().ToList();
            List<ArticleViewModel> articleViewModelList = new List<ArticleViewModel>();

            foreach (Sitecore.Data.Items.Item articleItem in articleItems)
            {
                //projectExampleLogger.Info("Title: " + articleItem.Fields["Title"].Value + ", Body: " + articleItem.Fields["Body"].Value + ",Summary: " + articleItem.Fields["Summary"].Value);

                ArticleViewModel articleViewModel = new ArticleViewModel()
                {
                    ArticleModel = new ArticleModel() { Title = articleItem.Fields["ArticleTitle"].Value, Body = articleItem.Fields["ArticleBody"].Value, Summary = articleItem.Fields["ArticleSummary"].Value },
                    Url = Sitecore.Links.LinkManager.GetItemUrl(articleItem)
                };

                articleViewModelList.Add(articleViewModel);
            }

            var viewModel = new ArticleListViewModel
            {
                ArticleList = articleViewModelList
            };

            return View(viewModel);
        }

        public ActionResult Display()
        {
            var currentContextItem = Sitecore.Context.Item;

            ArticleModel articleModel = new ArticleModel()
            {
                Body = currentContextItem.Fields["ArticleBody"].Value
            };

            return View(articleModel);
        }
    }
}