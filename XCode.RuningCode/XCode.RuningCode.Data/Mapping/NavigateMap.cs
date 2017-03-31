using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
{
    public class NavigateMap : EntityTypeConfiguration<Navigate>
    {
        public NavigateMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).HasMaxLength(20).IsRequired();
            this.Property(t => t.ControllerName).HasMaxLength(50).IsOptional();
            this.Property(t => t.ActionName).HasMaxLength(50).IsOptional();
            this.Property(t => t.IconClassCode).HasMaxLength(20);
            this.HasOptional(t => t.Parent);
        }
    }
}