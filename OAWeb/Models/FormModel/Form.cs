using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FormModel
{
    public class Form : BaseModel
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        [Display(Name = "表单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        public string Descript { get; set; }

        /// <summary>
        ///直接从设计器保存的html
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 解析之后保存的html
        /// </summary>
        public string Parse_Content { get; set; }

        /// <summary>
        /// 字段的集合
        /// </summary>
        public virtual ICollection<Field> Field { get; set; }
    }
}