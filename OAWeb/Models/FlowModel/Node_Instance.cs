using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    /// <summary>
    /// 记录节点详细信息
    /// </summary>
    public class Node_Instance : BaseModel
    {
        /// <summary>
        /// 节点
        /// </summary>
        public string NodeId { get; set; }
        public virtual Node Node { get; set; }

        /// <summary>
        /// 流程实例
        /// </summary>
        public string Flow_InstanceId { get; set; }
        public virtual Flow_Instance Flow_Instance { get; set; }

        /// <summary>
        /// 操作此节点的人
        /// </summary>
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}