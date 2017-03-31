using System.Collections.Generic;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    public class Navigate:BaseEntity
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Name { get; set; }

        public string IconClassCode { get; set; }

        public int? ParentID { get; set;}

        public Navigate Parent { get; set; }

        public bool Active { get; set; }

        public int? SoreOrder { get; set; }

        public virtual ICollection<Navigate> Children { get; set; } = new List<Navigate>();
    }
}