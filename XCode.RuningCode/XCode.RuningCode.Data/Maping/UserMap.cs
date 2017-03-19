using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Maping
{
    /// <summary>
    /// 用户表配置
    /// </summary>
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.LoginName).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            Property(item => item.Email).HasColumnType("varchar").IsRequired().HasMaxLength(36);
            Property(item => item.Password).HasColumnType("varchar").IsRequired().HasMaxLength(36);
            Property(item => item.RealName).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Status).IsRequired();
        }
    }
}
