using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping
{
    public class NoticeMap : EntityTypeConfiguration<Notice>
    {
        public NoticeMap()
        {
            HasKey(item => item.Id);
        }
    }
}
