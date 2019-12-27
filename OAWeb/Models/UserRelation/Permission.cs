using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.UserRelation
{
    public class Permission : BaseModel
    {
        /// <summary>
        /// 权限所属角色
        /// </summary>
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }

        /// <summary>
        /// 对应的操作
        /// </summary>
        public string Action { get; set; }

        //权限所能控制控件
    }
}