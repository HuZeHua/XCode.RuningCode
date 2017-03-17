using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class RoleEntity : BaseEntity
    {

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
