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

        public string TypeName => Type.value_name();

        public string Name { get; set; }

        public string IconClassCode { get; set; }

        //public NavigateDto Parent { get;  set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? SoreOrder { get; set; }

        public int ParentId { get; set; }
    }
}
