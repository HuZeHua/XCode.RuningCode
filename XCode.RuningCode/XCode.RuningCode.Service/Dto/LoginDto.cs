using System.ComponentModel;

namespace XCode.RuningCode.Service.Dto
{
    public class LoginDto
    {
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("记住我")]
        public bool RememberMe { get; set; }
    }
}