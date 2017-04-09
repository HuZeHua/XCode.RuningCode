using System.Collections.Generic;
using System.Collections.ObjectModel;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity.Blog
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }=new Collection<Article>();
    }
}
