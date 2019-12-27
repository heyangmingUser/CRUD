using OAWeb.Models.FormModel;
using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models.FlowModel
{
    /// <summary>
    /// 流程实例
    /// </summary>
    public class Flow_Instance : BaseModel
    {
        /// <summary>
        /// 流程模板
        /// </summary>
        public string FlowId { get; set; }
        public virtual Flow Flow { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public string UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        ///表单实例
        /// </summary>
        public string Form_InstanceId { get; set; }
        public virtual Form_Instance Form_Instance { get; set; }

        /// <summary>
        /// 流程的状态，即运行到哪一步，默认的为Start
        /// </summary>
        public InstanceStatus state { get; set; } = InstanceStatus.Start;
    }

    public enum InstanceStatus
    {
        /// <summary>
        /// 开始，创建实例的时候应该为开始状态，默认状态，然后立马转化成等待状态
        /// </summary>
        Start = 0,

        /// <summary>
        /// 等待中,没结束的状态全部为等待状态
        /// </summary>
        Wait = 1,

        /// <summary>
        /// 结束状态，最后一个节点操作完成后为结束状态
        /// </summary>
        End = 2,

    }
}