using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using AnasBimbel.Database;
using AnasBimbel.Interfaces;
using AnasBimbel.Models;

namespace AnasBimbel.Services
{
    public class Articles : Base, IArticles
    {
        public Articles(IDataContext datacontext) : base(datacontext)
        {
        }

        public int Create(ArticleModel model)
        {
            var Title = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Title",
                Value = model.Title
            };

            var TitleURL = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "TitleURL",
                Value = model.TitleURL
            };

            var ShortDescription = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "ShortDescription",
                Value = model.ShortDescription
            };

            var Description = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Description",
                Value = model.Description
            };

            var ImageURL = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "ImageURL",
                Value = model.ImageURL
            };

            var Keywords = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Keywords",
                Value = model.Keywords
            };

            var IsPublished = new SqlParameter()
            {
                DbType = DbType.Boolean,
                ParameterName = "IsPublished",
                Value = model.IsPublished??(object)DBNull.Value
            };

            var PublishedDate = new SqlParameter()
            {
                DbType = DbType.DateTime,
                ParameterName = "PublishedDate",
                Value = model.PublishedDate??(object)DBNull.Value
            };

            return this.datacontext.Database.SqlQuery<int>("EXEC Articles_Create @Title,@TitleURL,@ShortDescription,@Description,@ImageURL,@Keywords,@IsPublished,@PublishedDate", Title, TitleURL, ShortDescription, Description,ImageURL, Keywords,IsPublished, PublishedDate).FirstOrDefault<int>();
        }

        public bool Delete(int id)
        {
            var Id = new SqlParameter()
            {
                DbType = DbType.Int32,
                ParameterName = "Id",
                Value = id
            };

            return this.datacontext.Database.SqlQuery<bool>("EXEC Articles_Delete @Id", Id).FirstOrDefault<bool>();
        }

        public ArticleModel Read(int id)
        {
            var Id = new SqlParameter()
            {
                DbType = DbType.Int32,
                ParameterName = "Id",
                Value = id
            };

            return this.datacontext.Database.SqlQuery<ArticleModel>("EXEC Articles_Read @Id", Id).FirstOrDefault<ArticleModel>();
        }

        public ArticleModel ReadByTitleURL(string titleURL)
        {
            var TitleURL = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "TitleURL",
                Value = titleURL
            };

            return this.datacontext.Database.SqlQuery<ArticleModel>("EXEC Articles_ReadByTitleURL @TitleURL", TitleURL).FirstOrDefault<ArticleModel>();
        }

        public bool Update(ArticleModel model)
        {
            var Id = new SqlParameter()
            {
                DbType = DbType.Int32,
                ParameterName = "Id",
                Value = model.Id
            };

            var Title = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Title",
                Value = model.Title
            };

            var TitleURL = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "TitleURL",
                Value = model.TitleURL
            };

            var ShortDescription = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "ShortDescription",
                Value = model.ShortDescription
            };

            var Description = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Description",
                Value = model.Description
            };

            var ImageURL = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "ImageURL",
                Value = model.ImageURL
            };

            var Keywords = new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = "Keywords",
                Value = model.Keywords
            };

            var IsPublished = new SqlParameter()
            {
                DbType = DbType.Boolean,
                ParameterName = "IsPublished",
                Value = model.IsPublished
            };

            var PublishedDate = new SqlParameter()
            {
                DbType = DbType.DateTime,
                ParameterName = "PublishedDate",
                Value = model.PublishedDate
            };

            return this.datacontext.Database.SqlQuery<bool>("EXEC Articles_Update @Id,@Title,@TitleURL,@ShortDescription,@Description,@ImageURL,@Keywords,@IsPublished,@PublishedDate", Id, Title, TitleURL, ShortDescription, Description,ImageURL, Keywords, IsPublished, PublishedDate).FirstOrDefault<bool>();
        }

        public List<ArticleModel> ReadAll()
        {
            return this.datacontext.Database.SqlQuery< ArticleModel>("EXEC Articles_ReadAll").ToList<ArticleModel>();
        }

        public List<ArticleModel> ReadAllPublishedOnes()
        {
            return this.datacontext.Database.SqlQuery<ArticleModel>("EXEC Articles_ReadPublishedOnes").ToList<ArticleModel>();
        }
    }
}
