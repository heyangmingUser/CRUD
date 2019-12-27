using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceFlowAction : Container, IServiceFlowAction
    {
        public Tuple<bool, string> Add(FlowAction flowAction)
        {
            if (!string.IsNullOrWhiteSpace(flowAction.NodeId))
            {
                if (!db.FlowAction.Any(r => r.Id == flowAction.Id))
                {
                    var result = flowAction.Insert() > 0;
                    return Tuple.Create(result, result ? " " : "添加成功");
                }
                else
                    return Tuple.Create(false, "此流程此节点的操作已经存在!");
            }
            else
                return Tuple.Create(false, "对应的节点和流程不能为空");
        }

        public IQueryable<FlowAction> GetAllFlowAction()
        {
            return db.FlowAction;
        }

        public FlowAction GetFlowActionById(string Id)
        {
            return db.FlowAction.FirstOrDefault(r => r.Id == Id);
        }

        public IQueryable<FlowAction> GetFlowActionsByNodeId(string Id)
        {
            return db.FlowAction.Where(r => r.NodeId == Id);
        }

        public Tuple<bool, string> Update(FlowAction flowAction)
        {
            if (db.FlowAction.Any(r => r.Id == flowAction.Id))
            {
                var result = flowAction.Update() > 0;
                return Tuple.Create(result, result ? " " : "修改成功!");
            }
            else
                return Tuple.Create(false, "不存在此操作!");
        }
    }
}