using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Config
{
    /// <summary>
    /// 角色菜单关系表配置
    /// </summary>
    public class RoleMenuConfig : EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuConfig()
        {
            ToTable("RoleMenu");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.RoleId).IsRequired();
            Property(item => item.MenuId).IsRequired();
        }
    }
}
