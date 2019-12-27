using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FormModel
{
    public class Field_Instance : BaseModel
    {
        /// <summary>
        /// 字段信息
        /// </summary>
        public string FieldId { get; set; }
        public virtual Field Field { get; set; }

        /// <summary>
        /// 字段值，实际存储的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 表单实例作为值的唯一标识，集成到表单
        /// </summary>
        public string Form_InstanceId { get; set; }
        public virtual Form_Instance Form_Instance { get; set; }


    }
}