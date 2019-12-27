using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    /// <summary>
    /// 流程模板
    /// </summary>
    public class Flow : BaseModel
    {
        /// <summary>
        /// 流程名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 节点集合
        /// </summary>
        public virtual ICollection<Node> Nodes { get; set; }
    }
}