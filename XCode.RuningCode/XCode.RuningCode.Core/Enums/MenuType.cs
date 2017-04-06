
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

    public enum MenuName
    {
        [FriendlyName("无")]
        None,
        [FriendlyName("系统设置")]
        SystemSetting,

        [FriendlyName("博客设置")]
        BlogSetting,

        [FriendlyName("日志查看")]
        Log,

        [FriendlyName("邮件系统")]
        Mail,

        [FriendlyName("示例文档")]
        Demo,

        [FriendlyName("高级示例")]
        DemoMost,


    }
}
