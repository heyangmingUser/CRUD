using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FormModel
{
    public class Field : BaseModel
    {
        /// <summary>
        /// 组件
        /// </summary>
        public string ComponentId { get; set; }
        public virtual Component Component { get; set; }

        /// <summary>
        /// 组件值，这里可以为空
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 组件对应的标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 模板表单
        /// </summary>
        public string FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}