using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceflowInstance : Container, IServiceflowInstance
    {
        public Tuple<bool, string> AddFlowActionInstance(FlowAction_Instance flowAction_Instance)
        {
            if (!string.IsNullOrWhiteSpace(flowAction_Instance.FlowActionId) && string.IsNullOrWhiteSpace(flowAction_Instance.Node_InstanceId))
            {
                if (!db.FlowAction_Instance.Any(r => r.Id == flowAction_Instance.Id))
                {
                    var result = flowAction_Instance.Insert() > 0;
                    return Tuple.Create(result, result ? " " : "添加成功");
                }
                else
                    return Tuple.Create(false, "此节点的操作实例已经存在!");
            }
            else
                return Tuple.Create(false, "操作信息和操作节点实例不能为空!");

        }

        public Tuple<bool, string> AddFlowActionTraceData(FlowActionTraceData flowActionTraceData)
        {
            if (!string.IsNullOrWhiteSpace(flowActionTraceData.Form_InstanceId) && string.IsNullOrWhiteSpace(flowActionTraceData.Flow_InstanceId))
            {
                if (!db.FlowActionTraceData.Any(r => r.Id == flowActionTraceData.Id))
                {
                    var result = flowActionTraceData.Insert() > 0;
                    return Tuple.Create(result, result ? " " : "添加成功");
                }
                else
                    return Tuple.Create(false, "此任务实例已经存在!");
            }
            else
                return Tuple.Create(false, "流程实例和表单实例不能为空!");
        }

        public Tuple<bool, string> AddFlowInstance(Flow_Instance flow_Instance)
        {
            if (!string.IsNullOrWhiteSpace(flow_Instance.FlowId))
            {
                if (!db.FlowAction_Instance.Any(r => r.Id == flow_Instance.Id))
                {
                    var result = flow_Instance.Insert() > 0;
                    return Tuple.Create(result, result ? " " : "添加成功");
                }
                else
                    return Tuple.Create(false, "此流程实例已经存在!");
            }
            else
                return Tuple.Create(false, "流程模板不能为空!");
        }

        public Tuple<bool, string> AddNodeInstance(Node_Instance node_Instance)
        {
            if (!string.IsNullOrWhiteSpace(node_Instance.NodeId) && string.IsNullOrWhiteSpace(node_Instance.Flow_InstanceId))
            {
                if (!db.FlowActionTraceData.Any(r => r.Id == node_Instance.Id))
                {
                    var result = node_Instance.Insert() > 0;
                    return Tuple.Create(result, result ? " " : "添加成功");
                }
                else
                    return Tuple.Create(false, "此流程实例已经存在!");
            }
            else
                return Tuple.Create(false, "节点模板和流程实例不能为空!");
        }

        public IQueryable<FlowAction_Instance> GetAllFlowAction_Instance()
        {
            return db.FlowAction_Instance;
        }

        public IQueryable<FlowActionTraceData> GetAllFlowTraceData()
        {
            return db.FlowActionTraceData;
        }

        public IQueryable<Flow_Instance> GetAllFlow_Instance()
        {
            return db.Flow_Instance;
        }

        public IQueryable<Node_Instance> GetAllNode_Instance()
        {
            return db.Node_Instance;
        }

        public FlowActionTraceData GetFlowActionTraceDataById(string Id)
        {
            return db.FlowActionTraceData.FirstOrDefault(r => r.Id == Id);
        }

        public FlowAction_Instance GetFlowAction_InstanceById(string Id)
        {
            return db.FlowAction_Instance.FirstOrDefault(r => r.Id == Id);
        }

        public Flow_Instance GetFlow_InstancById(string Id)
        {
            return db.Flow_Instance.FirstOrDefault(r => r.Id == Id);
        }

        public Node_Instance GetNode_InstanceById(string Id)
        {
            return db.Node_Instance.FirstOrDefault(r => r.Id == Id);
        }

        public Tuple<bool, string> UpdateFlowActionInstance(FlowAction_Instance flowAction_Instance)
        {
            if (db.FlowAction.Any(r => r.Id == flowAction_Instance.Id))
            {
                var result = flowAction_Instance.Update() > 0;
                return Tuple.Create(result, result ? "" : "修改成功");
            }
            else
                return Tuple.Create(false, "此操作不存在!");
        }

        public Tuple<bool, string> UpdateFlowActionTraceData(FlowActionTraceData flowActionTraceData)
        {
            if (db.FlowAction.Any(r => r.Id == flowActionTraceData.Id))
            {
                var result = flowActionTraceData.Update() > 0;
                return Tuple.Create(result, result ? "" : "修改成功");
            }
            else
                return Tuple.Create(false, "此操作不存在!");
        }

        public Tuple<bool, string> UpdateFlowInstance(Flow_Instance flow_Instance)
        {
            if (db.FlowAction.Any(r => r.Id == flow_Instance.Id))
            {
                var result = flow_Instance.Update() > 0;
                return Tuple.Create(result, result ? "" : "修改成功");
            }
            else
                return Tuple.Create(false, "此操作不存在!");
        }

        public Tuple<bool, string> UpdateNodeInstance(Node_Instance node_Instance)
        {
            if (db.FlowAction.Any(r => r.Id == node_Instance.Id))
            {
                var result = node_Instance.Update() > 0;
                return Tuple.Create(result, result ? "" : "修改成功");
            }
            else
                return Tuple.Create(false, "此操作不存在!");
        }
    }
}