using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    /// <summary>
    /// 登录日志表配置
    /// </summary>
    public class LoginLogMap : EntityTypeConfiguration<LoginLog>
    {
        public LoginLogMap()
        {
            ToTable("LoginLog");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.LoginName).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            Property(item => item.UserId).IsRequired();
            Property(item => item.IP).HasColumnType("varchar").IsOptional().HasMaxLength(15);
            Property(item => item.Mac).HasColumnType("varchar").IsOptional().HasMaxLength(40);
        }
    }
}
