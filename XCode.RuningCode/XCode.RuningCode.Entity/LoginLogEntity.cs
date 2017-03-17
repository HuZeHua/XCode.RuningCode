using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 用户登录日志实体
    /// </summary>
    public class LoginLogEntity : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 电脑的MAC地址
        /// </summary>
        public string Mac { get; set; }
    }
}
