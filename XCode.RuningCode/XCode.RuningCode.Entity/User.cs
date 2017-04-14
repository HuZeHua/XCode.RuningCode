using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    public class User : BaseEntity
    {
        public string LoginName { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Location { get; set; }

        public string QQ { get; set; }

        public string Github { get; set; }

        public string Company { get; set; }

        public string Link { get; set; }

        public string Password { get; set; }

        public string Telephone { get; set; }

        public byte Status { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    }
}
