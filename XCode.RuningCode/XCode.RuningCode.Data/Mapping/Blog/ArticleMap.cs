using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Title).IsRequired().HasMaxLength(100);

            this.Property(t => t.MetaKeywords).HasMaxLength(200);
            this.Property(t => t.MetaDescription).HasMaxLength(200);
            this.Property(t => t.MetaTitle).HasMaxLength(200);
        }
    }
}
