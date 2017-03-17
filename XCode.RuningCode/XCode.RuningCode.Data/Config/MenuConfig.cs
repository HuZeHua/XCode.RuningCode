using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Config
{
    /// <summary>
    /// 菜单表配置
    /// </summary>
    public class MenuConfig : EntityTypeConfiguration<Menu>
    {
        public MenuConfig()
        {
            ToTable("Menu");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Type).IsRequired();
            Property(item => item.Url).HasColumnType("varchar").IsRequired().HasMaxLength(300);
        }
    }
}
