using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.RuningCode.Service.Dto
{
    public class RoleNavigateDto : BaseDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int NavigateId { get; set; }
    }
}
