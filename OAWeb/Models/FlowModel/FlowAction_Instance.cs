using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    /// <summary>
    /// 记录操作详细信息
    /// </summary>
    public class FlowAction_Instance : BaseModel
    {
        /// <summary>
        /// 节点实例
        /// </summary>
        public string Node_InstanceId { get; set; }
        public virtual Node_Instance Node_Instance { get; set; }

        /// <summary>
        /// 操作Action
        /// </summary>
        public string FlowActionId { get; set; }
        public virtual FlowAction FlowAction { get; set; }

    }
}