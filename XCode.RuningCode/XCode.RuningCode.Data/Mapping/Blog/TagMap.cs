using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Name).IsRequired().HasMaxLength(100);
            this.Property(t => t.Description).HasMaxLength(200);
        }
    }
}
