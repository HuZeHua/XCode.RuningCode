using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    public class Navigate : BaseEntity
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Url { get; set; }

        public MenuType Type { get; set; }

        public string Name { get; set; }

        public string IconClassCode { get; set; }

        public Navigate Parent { get; protected set; }

        public int? ParentId { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? SoreOrder { get; set; }

        public virtual IList<Navigate> Children { get; protected set; } = new List<Navigate>();

        public void add_children_nav(Navigate nav)
        {
            if (nav == null)
            {
                throw new Exception("");
            }
            nav.Parent = this;
            Children.Add(nav);
        }
    }
}