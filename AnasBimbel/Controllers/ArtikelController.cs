using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnasBimbel.Interfaces;
using AnasBimbel.Database;
using AnasBimbel.Services;
using AnasBimbel.Models;

namespace AnasBimble.Controllers
{
    public class ArtikelController : Controller
    {
        private Articles _services;
        public ArtikelController(IArticles articles)
        {
            _services = (Articles)articles;
        }

        [AcceptVerbs("GET")]
        [AllowAnonymous]
        public ActionResult Index(string titleurl)
        {
            List<ArticleModel> list = _services.ReadAllPublishedOnes().OrderByDescending(o=>o.PublishedDate).ToList();
            ArticleModel model;
            if (string.IsNullOrEmpty(titleurl))
            {
                model = list.FirstOrDefault();
            }
            else
            {
                model = list.Where(w => w.TitleURL == titleurl).FirstOrDefault();
            }

            ViewData["content"] = model;
            ViewData["list"] = list.Where(w => w.Id != model.Id).Take(3).ToList();
            return View();
        }
    }
}