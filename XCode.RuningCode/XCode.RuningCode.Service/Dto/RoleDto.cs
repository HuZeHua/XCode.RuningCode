using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XCode.RuningCode.Service.Dto
{
    /// <summary>
    /// 角色DTO
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required, DisplayName("角色名称"), MinLength(2), MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required, DisplayName("描述"), MinLength(1), MaxLength(50)]
        public string Description { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }=new List<PermissionDto>();

        public ICollection<NavigateDto> Navigates { get; set; }=new List<NavigateDto>();

        public bool Active { get; set; }
    }
}
