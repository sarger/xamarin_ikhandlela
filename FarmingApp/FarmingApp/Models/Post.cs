using System;
using System.Collections.Generic;
using System.Text;

namespace FarmingApp.Models
{
    public class Post
    {

        public int Id { get; set; }
        public string Content { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string SubContent
        {
             get {   
                if (Content.Length > 20)
                    return Content.Substring(0, 20);
             else
                    return Content; 
            } 
        }
        

    }
}
