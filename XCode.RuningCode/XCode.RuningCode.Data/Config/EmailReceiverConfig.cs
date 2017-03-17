﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Config
{
    /// <summary>
    /// 邮件接收人表配置
    /// </summary>
    public class EmailReceiverConfig : EntityTypeConfiguration<EmailReceiverEntity>
    {
        public EmailReceiverConfig()
        {
            ToTable("EmailReceiver");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(item => item.Type).IsRequired();
            HasRequired(item => item.EmailPool).WithMany(item => item.Receivers).HasForeignKey(item => item.EmailId);
        }
    }
}
