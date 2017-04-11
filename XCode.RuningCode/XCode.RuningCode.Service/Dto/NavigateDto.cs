using System.Collections.Generic;
using System.ComponentModel;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;

namespace XCode.RuningCode.Service.Dto
{
    public class NavigateDto : BaseDto
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Url { get; set; }

        public MenuType Type { get; set; }

        public string TypeName
        {
            get { return Type.value_name(); }
        }

        public string Name { get; set; }

        public string IconClassCode { get; set; }

        public NavigateDto Parent { get; protected set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? SoreOrder { get; set; }

        public int ParentId => Parent != null ? Parent.Id : 0;

        //public virtual ICollection<NavigateDto> Children { get; protected set; } = new List<NavigateDto>();
    }
}
