using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using AnasBimbel.Interfaces;
using AnasBimbel.Models;
using AnasBimbel.Messaging;

namespace AnasBimble.Controllers.API
{
    [RoutePrefix("API/ARTIKEL")]
    public class ArtikelController : ApiController
    {
        private IArticles _services;
        public ArtikelController(IArticles services)
        {
            _services = services;
        }

        [Route("CARI")]
        [AcceptVerbs("GET")]
        public async Task<List<ArticleModel>> Cari()
        {
            List<ArticleModel> result = await Task.Run<List<ArticleModel>>(() => {
                List<ArticleModel> list = _services.ReadAllPublishedOnes().OrderByDescending(o=>o.PublishedDate).Take(3).ToList();
                return list;
            });
            return result;
        }
    }
}
