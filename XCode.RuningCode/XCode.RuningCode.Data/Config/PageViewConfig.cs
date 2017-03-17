using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Config
{
    /// <summary>
    /// 用户表配置
    /// </summary>
    public class PageViewConfig : EntityTypeConfiguration<PageView>
    {
        public PageViewConfig()
        {
            ToTable("PageView");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.UserId);
            Property(item => item.LoginName).HasColumnType("varchar").HasMaxLength(20);
            Property(item => item.Url).HasColumnType("varchar").IsRequired().HasMaxLength(300);
        }
    }
}
