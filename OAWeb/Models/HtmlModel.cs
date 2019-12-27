using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models
{
    /// <summary>
    /// 用来连接表单模板和设计器信息的模板
    /// </summary>
    public class HtmlModel
    {
        /// <summary>
        /// 表单设计器的内容
        /// </summary>
        public string HtmlContent { get; set; }

        /// <summary>
        /// 表单的Id
        /// </summary>
        public string FormId { get; set; }


    }
}