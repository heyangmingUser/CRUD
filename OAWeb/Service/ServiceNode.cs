using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceNode : Container, IServiceNode
    {
        public Tuple<bool, string> Add(Node node)
        {
            if (!string.IsNullOrWhiteSpace(node.Name) && !string.IsNullOrWhiteSpace(node.FlowId))
            {
                if (!db.Node.Any(r => r.Id == node.Id && r.Name == node.Name && r.FlowId == node.FlowId))
                {
                    var result = node.Insert() > 0;
                    return Tuple.Create(result, result ? "" : "添加成功");
                }
                else
                    return Tuple.Create(false, "已经存在此流程的此节点");
            }
            else
                return Tuple.Create(false, "节点名称、节点编号、节点所属流程不能为空");
        }

        public Tuple<bool, string> Delete(string Id)
        {
            //删除之前应删除节点所对应的操作，暂时忽略
            var node = db.Node.FirstOrDefault(r => r.Id == Id);
            if (node != null)
            {
                var result = node.Delete() > 0;
                return Tuple.Create(result, result ? "" : "删除成功");
            }
            else
                return Tuple.Create(false, "不存在此节点");
        }

        public IQueryable<Node> GetAllNode()
        {
            return db.Node;
        }

        public IQueryable<Node> GetNodeByFlowId(string flowId)
        {
            return db.Node.Where(r => r.FlowId == flowId);
        }

        public Node GetNodeById(string Id)
        {
            return db.Node.FirstOrDefault(r => r.Id == Id);
        }

        public Tuple<bool, string> Update(Node node)
        {
            if (db.Node.Any(r => r.Id == node.Id))
            {
                var result = node.Update() > 0;
                return Tuple.Create(result, result ? "" : "修改成功");
            }
            else
                return Tuple.Create(false, "未找到此节点");
        }
    }
}