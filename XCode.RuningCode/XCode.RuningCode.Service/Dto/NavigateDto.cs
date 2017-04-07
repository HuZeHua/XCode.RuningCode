using System.Collections.Generic;
using System.ComponentModel;
using XCode.RuningCode.Core.Enums;

namespace XCode.RuningCode.Service.Dto
{
    public class NavigateDto:BaseDto
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Url { get; set; }

        public MenuType Type { get; set; }

        public string Name { get; set; }

        public string IconClassCode { get; set; }

        public NavigateDto Parent { get; protected set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? SoreOrder { get; set; }

        public virtual ICollection<NavigateDto> Children { get; protected set; } = new List<NavigateDto>();
    }
}
