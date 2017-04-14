using System;
using System.ComponentModel;

namespace XCode.RuningCode.Entity.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDateTime = DateTime.Now;
        }

        public int Id { get; set; }

        
        public DateTime CreateDateTime { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
