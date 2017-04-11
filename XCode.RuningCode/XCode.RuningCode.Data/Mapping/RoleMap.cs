using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    /// <summary>
    /// 角色表配置
    /// </summary>
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Roles");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Description).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);

            HasMany(t => t.Permissions).WithMany().Map(m =>
            {
                m.ToTable("RolePermission");
                m.MapLeftKey("RoleID");
                m.MapRightKey("PermissionID");
            });

            HasMany(t => t.Navigates).WithMany().Map(m =>
            {
                m.ToTable("RoleNavigate");
                m.MapLeftKey("RoleID");
                m.MapRightKey("NavigateID");
            });
        }
    }
}
