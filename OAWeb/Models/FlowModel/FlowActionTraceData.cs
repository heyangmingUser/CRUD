using OAWeb.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    /// <summary>
    /// 结合当前表单和当前流程
    /// </summary>
    public class FlowActionTraceData : BaseModel
    {
        /// <summary>
        /// 流程实例
        /// </summary>
        public string Flow_InstanceId { get; set; }
        public virtual Flow_Instance Flow_Instance { get; set; }

        /// <summary>
        /// 表单实例
        /// </summary>
        public string Form_InstanceId { get; set; }
        public virtual Form_Instance Form_Instance { get; set; }
    }
}