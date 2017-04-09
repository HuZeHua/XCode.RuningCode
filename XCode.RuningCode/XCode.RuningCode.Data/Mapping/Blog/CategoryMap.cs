using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Name).IsRequired().HasMaxLength(100);
            this.Property(t => t.MetaKeywords).HasMaxLength(200);
            this.Property(t => t.MetaDescription).HasMaxLength(200);
            this.Property(t => t.MetaTitle).HasMaxLength(200);

        }
    }
}
