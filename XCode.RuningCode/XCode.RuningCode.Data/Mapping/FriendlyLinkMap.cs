using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    /// <summary>
    /// 用户表配置
    /// </summary>
    public class FriendlyLinkMap : EntityTypeConfiguration<FriendlyLink>
    {
        public FriendlyLinkMap()
        {
            ToTable("FriendlyLink");
            HasKey(item => item.Id);
        }
    }
}
