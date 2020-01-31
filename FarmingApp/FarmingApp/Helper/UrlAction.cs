using System;
using System.Collections.Generic;
using System.Text;

namespace FarmingApp.Helper
{
    public class UrlAction
    {

        private UrlAction(string value) { Value = value; }

        public string Value { get; set; }

        public static UrlAction AddComment { get { return new UrlAction("CommentAdd.php?"); } }
        public static UrlAction GetCategoryById { get { return new UrlAction("CategoryGet.php?Id="); } }

        public static UrlAction GetAllCategory { get { return new UrlAction("PostCategoryGetAll.php?"); } }

        public static UrlAction AddCategory { get { return new UrlAction("PostCategoryAdd.php?"); } }

        public static UrlAction DeleteCategory { get { return new UrlAction("PostCategoryDelete.php?"); } }

        public static UrlAction EditCategory { get { return new UrlAction("PostCategoryEdit.php?"); } }

        public static UrlAction GetPostsByCategoryId { get { return new UrlAction("PostsGetByCategoryId.php?CategoryId="); } }
        public static UrlAction GetPostById { get { return new UrlAction("PostGetById.php?Id="); } }

    }
}
