using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    public class Node : BaseModel
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上一节点编号
        /// </summary>
        public int PreNodeNumber { get; set; }

        /// <summary>
        /// 下一节点编号
        /// </summary>
        public int NextNodeNumber { get; set; }

        /// <summary>
        /// 节点编号
        /// </summary>
        public int NodeNumber { get; set; }

        /// <summary>
        /// 所属流程
        /// </summary>
        public string FlowId { get; set; }
        public virtual Flow Flow { get; set; }

        /// <summary>
        /// 节点对应的操作的集合
        /// </summary>
        public virtual ICollection<FlowAction> FlowActions { get; set; }

        /// <summary>
        /// 步骤类型
        /// </summary>
        public StepType StepType { get; set; }


    }

    public enum StepType
    {
        /// <summary>
        /// 第一步
        /// </summary>
        FirstStep = 0,

        /// <summary>
        /// 正常步骤
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 转入子流程
        /// </summary>
        MoveIntoSubprocesses = 2,

        /// <summary>
        /// 最后一个
        /// </summary>
        EndStep = 4
    }

    public enum WriteOrRead
    {
        /// <summary>
        /// 控件只读
        /// </summary>
        Write = 0,
        /// <summary>
        /// 控件只写
        /// </summary>
        ReadOnly = 1,

    }
}