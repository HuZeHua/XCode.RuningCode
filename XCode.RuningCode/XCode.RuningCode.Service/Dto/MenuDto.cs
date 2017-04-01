using System.ComponentModel;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Service.Dto
{
    /// <summary>
    /// 菜单DTO
    /// </summary>
    public class MenuDto : BaseDto
    {
        /// <summary>
        /// 上级ID
        /// </summary>
        [DisplayName("上级分类")]
        public int ParentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public MenuType Type { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get { return Type.value_name(); }
        }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [DisplayName("URL")]
        public string Url { get; set; }

        [DisplayName("排序")]
        public int Order { get; set; }
    }
}
