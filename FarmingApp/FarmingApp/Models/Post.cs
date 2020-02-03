using System;
using System.Collections.Generic;
using System.Text;

namespace FarmingApp.Models
{
    public class Post
    {

        public int Id { get; set; }
        public string Content { get; set; }

        public List<UserComment> Comments { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }


    }
}
