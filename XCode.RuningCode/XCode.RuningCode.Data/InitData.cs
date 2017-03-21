using System.Data.Entity;
using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Data.Mapping;

namespace XCode.RuningCode.Data
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public static class InitData
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<XCodeContext, Configuration>());
        }
    }
}
