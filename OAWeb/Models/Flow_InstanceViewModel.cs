using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models
{
    public class Flow_InstanceViewModel
    {
        /// <summary>
        /// 表单
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// 流程
        /// </summary>
        public string FlowId { get; set; } 

        /// <summary>
        /// 使用用户的信息
        /// </summary>
        public string UserId { get; set; }
    }
}