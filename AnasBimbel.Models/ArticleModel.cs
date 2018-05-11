using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnasBimbel.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {

        }

        public ArticleModel(int id, string title, string titleURL, string shortDescription, string description, string imageURL, string keywords)
        {
            Id = id;
            Title = title;
            TitleURL = titleURL;
            ShortDescription = shortDescription;
            Description = description;
            ImageURL = imageURL;
            Keywords = keywords;
        }

        public ArticleModel(int id, string title, string titleURL, string shortDescription, string description,string imageURL,string keywords,bool? isPublished,Nullable<DateTime> publishedDate)
        {
            Id = id;
            Title = title;
            TitleURL = titleURL;
            ShortDescription = shortDescription;
            Description = description;
            ImageURL = imageURL;
            Keywords = keywords;
            IsPublished = isPublished;
            PublishedDate = publishedDate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleURL { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Keywords { get; set; }
        public bool IsDeleted { get; set; }
	    public Nullable<DateTime> DeletedDate { get; set; }
	    public Nullable<DateTime> CreatedDate { get; set; }
        public bool? IsPublished { get; set; }
        public Nullable<DateTime> PublishedDate { get; set; }
        public string PublishedDateString
        {
            get
            {
                return string.Format("{0:dd MMM yyyy hh:mm tt}",PublishedDate);
            }
        }
    }
}
