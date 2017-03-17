namespace XCode.RuningCode.Service.Dto
{

    /// <summary>
    /// 基础查询类
    /// </summary>
    public class QueryBase
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 开始记录数
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Draw { get; set; }
    }
}
