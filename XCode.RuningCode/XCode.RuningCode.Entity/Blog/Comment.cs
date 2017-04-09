using System.Collections.Generic;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity.Blog
{
    public class Comment : BaseEntity
    {
        public User Author { get; set; }
        public string CommentText { get; set; }
        public bool Active { get; set; }

        public IList<Comment> Comments { get; set; }=new List<Comment>();
    }
}
