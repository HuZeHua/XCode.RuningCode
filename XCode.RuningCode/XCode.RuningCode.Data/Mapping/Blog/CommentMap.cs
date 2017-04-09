using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.HasKey(t => t.Id);
        }
    }
}
