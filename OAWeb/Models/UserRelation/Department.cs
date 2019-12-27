using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAWeb.Models.UserRelation
{
    public class Department : BaseModel
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        [Display(Name = "部门名称")]
        public string Name { get; set; }

        /// <summary>
        /// 此部门人员集合
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}