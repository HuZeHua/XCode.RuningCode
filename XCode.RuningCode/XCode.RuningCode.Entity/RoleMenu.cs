using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 角色菜单关系实体
    /// </summary>
    public class RoleMenu : BaseEntity
    {

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }
    }
}
