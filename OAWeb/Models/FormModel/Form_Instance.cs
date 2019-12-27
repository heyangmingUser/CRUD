using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FormModel
{
    //https://www.cnblogs.com/wangxiaohuo/archive/2012/08/22/2650893.html
    public class Form_Instance : BaseModel
    {
        /// <summary>
        ///表单模板
        /// </summary>
        public string FormId { get; set; }
        public virtual Form Form { get; set; }

        /// <summary>
        /// 字段实例集合
        /// </summary>
        public virtual ICollection<Field_Instance> Field_Instance { get; set; }
    }
}