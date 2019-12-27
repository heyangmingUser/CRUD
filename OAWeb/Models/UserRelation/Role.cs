using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAWeb.Models.UserRelation
{
    public class Role : BaseModel
    {

        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 此角色所对应的用户
        /// </summary>
        [Display(Name = "对应角色的用户")]
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// 此角色所对应的角色类型
        /// </summary>
        [Display(Name = "对应的角色")]
        public RoleType RoleType { get; set; }

        /// <summary>
        /// 角色对应的权限管理
        /// </summary>
        [Display(Name = "权限")]
        public string Permission { get; set; }


    }

    //角色类型
    public enum RoleType
    {
        /// <summary>
        /// 总经理或者局长
        /// </summary>
        GeneralManager = 0,

        /// <summary>
        /// 部长或者高级经理
        /// </summary>
        Minister = 1,

        /// <summary>
        /// 经理
        /// </summary>
        Maneger = 2,

        /// <summary>
        /// 主管
        /// </summary>
        Director = 3,

        /// <summary>
        /// 普通员工
        /// </summary>
        Employee = 4

    }
}