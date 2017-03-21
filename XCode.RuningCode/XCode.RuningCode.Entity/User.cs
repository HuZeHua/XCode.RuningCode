using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User : BaseEntity
    {

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        public bool Active { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    }
}
