using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    /// <summary>
    /// 角色表配置
    /// </summary>
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            ToTable("Permission");
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).HasMaxLength(20).IsRequired();
            this.Property(t => t.Category).HasMaxLength(20).IsRequired();
            this.Property(t => t.Description);
        }
    }
}
