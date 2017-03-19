using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    /// <summary>
    /// 角色表配置
    /// </summary>
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRole");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.RoleId).IsRequired();
            Property(item => item.UserId).IsRequired();
            HasRequired(item => item.User).WithMany(item => item.UserRoles).HasForeignKey(item => item.UserId);
        }
    }
}
