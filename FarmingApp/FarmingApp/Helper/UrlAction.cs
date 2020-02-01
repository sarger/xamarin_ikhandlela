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

        public static UrlAction GetAllPost { get { return new UrlAction("PostGetAll.php?"); } }

        public static UrlAction AddPost { get { return new UrlAction("PostAdd.php?"); } }

        public static UrlAction DeletePost { get { return new UrlAction("PostAdd.php?"); } }

        public static UrlAction EditPost { get { return new UrlAction("PostEdit.php?"); } }

        public static UrlAction GetPostByCategoryId { get { return new UrlAction("PostsGetByCategoryId.php?CategoryId="); } }

        public static UrlAction GetCommentsByPostId { get { return new UrlAction("CommentsGetByPostId.php?PostId="); } }


        public static UrlAction GetAllComments { get { return new UrlAction("xxxxxx.php?CategoryId="); } }


        public static UrlAction GetCommentById { get { return new UrlAction("xxxxxxxx.php?CommentId="); } }


        public static UrlAction AddCommentAsync { get { return new UrlAction("CommentAdd.php?PostId="); } }

        public static UrlAction EditComment { get { return new UrlAction("CommentAdd.php?PostId="); } }

        public static UrlAction DeleteComment { get { return new UrlAction("CommentDelete.php?PostId="); } }
        



    }
}
