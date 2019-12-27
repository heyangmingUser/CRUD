using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FormModel
{
    /// <summary>
    /// 组件
    /// </summary>
    public class Component : BaseModel
    {
        /// <summary>
        /// 组件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 组件类型
        /// </summary>
        public string Type { get; set; }

    }
}