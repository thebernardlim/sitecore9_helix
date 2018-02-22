using Sitecore.Feature.Blog.Models;
using Sitecore.Feature.Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Blog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult List()
        {
            var currentContextItem = Sitecore.Context.Item; // Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;

            List<Sitecore.Data.Items.Item> blogItems = currentContextItem.GetChildren().ToList();
            List<BlogViewModel> blogViewModelList = new List<BlogViewModel>();
            foreach(Sitecore.Data.Items.Item blogItem in blogItems)
            {
                BlogViewModel blogViewModel = new BlogViewModel()
                {
                    BlogModel = new BlogModel() { Title = blogItem.Fields["Title"].Value },
                    Url = Sitecore.Links.LinkManager.GetItemUrl(blogItem)
                };

                blogViewModelList.Add(blogViewModel);
            }

            var viewModel = new BlogListViewModel
            {
                BlogList = blogViewModelList
            };

            return View(viewModel);
        }
    }
}