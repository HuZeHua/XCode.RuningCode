using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Maping
{
    /// <summary>
    /// 邮件表配置
    /// </summary>
    public class EmailPoolMap : EntityTypeConfiguration<EmailPool>
    {
        public EmailPoolMap()
        {
            ToTable("EmailPool");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Title).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            Property(item => item.Content).HasColumnType("text").IsRequired();
            Property(item => item.FailTimes).IsRequired();
        }
    }
}
