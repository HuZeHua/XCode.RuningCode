
using XCode.RuningCode.Core.Attributes;

namespace XCode.RuningCode.Core.Enums
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        [FriendlyName("模块")]
        Module = 1,

        [FriendlyName("菜单")]
        Menu = 2,

        [FriendlyName("按钮")]
        ButtonType = 3
    }
}
