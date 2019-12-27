using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAWeb.Models.UserRelation
{
    public class User : BaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        //电话
        [Required]
        public string Tel { get; set; }

        //电子邮件
        [Required]
        public string Email { get; set; }

        //角色
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}