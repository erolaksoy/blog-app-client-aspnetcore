using System;

namespace WorksBlogProjectClient.Models
{
    public class BlogListModel
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } 

    }
}