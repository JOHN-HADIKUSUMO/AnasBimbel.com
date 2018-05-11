using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using AnasBimbel.Models;

namespace AnasBimbel.Interfaces
{
    public interface IArticles:IServices
    {
        int Create(ArticleModel model);
        ArticleModel Read(int id);
        ArticleModel ReadByTitleURL(string titleURL);
        bool Update(ArticleModel model);
        bool Delete(int id);
        List<ArticleModel> ReadAll();
        List<ArticleModel> ReadAllPublishedOnes();
    }
}
