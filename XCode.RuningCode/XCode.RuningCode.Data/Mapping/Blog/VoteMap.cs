using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class VoteMap : EntityTypeConfiguration<Vote>
    {
        public VoteMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.IPAddress).IsRequired().HasMaxLength(100);
        }
    }
}
