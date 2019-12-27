using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    public class FlowAction : BaseModel
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属节点
        /// </summary>
        public string NodeId { get; set; }
        public virtual Node Node { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public Operation Operation { get; set; }

    }
    public enum Operation
    {
        /// <summary>
        /// 提交
        /// </summary>
        Submit = 0,

        /// <summary>
        /// 退回
        /// </summary>
        Back = 1,


    }
}