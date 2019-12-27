using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceFlow : Container, IServiceFlow
    {
        public Tuple<bool, string> Add(Flow flow)
        {
            if (!string.IsNullOrWhiteSpace(flow.Name))
            {
                if (!db.Flow.Any(r => r.Id == flow.Id && r.Name == flow.Name))
                {
                    var result = flow.Insert() > 0;
                    return Tuple.Create(result, result ? "" : "添加失败");
                }
                else
                    return Tuple.Create(false, "");
            }
            else
                return Tuple.Create(false, "添加的模板名称不能为空!");
        }

        public Tuple<bool, string> Delete(string Id)
        {
            //暂不考虑解绑的问题
            var flow = db.Flow.FirstOrDefault(r => r.Id == Id);
            if (flow != null)
            {
                var result = flow.Delete() > 0;
                return Tuple.Create(result, result ? "" : "删除成功");
            }
            else
                return Tuple.Create(false, "不存在此流程模板");
        }

        public IQueryable<Flow> GetAllFlow()
        {
            return db.Flow;
        }

        public Flow GetFlowByFlowInstanceId(string Flow_InstanceId)
        {
            var flow_Instance = db.Flow_Instance.FirstOrDefault(r => r.Id == Flow_InstanceId);
            if (flow_Instance != null)
            {
                return db.Flow.FirstOrDefault(r => r.Id == flow_Instance.FlowId);
            }
            else
                return null;
        }

        public Flow GetFlowById(string Id)
        {
            return db.Flow.FirstOrDefault(r => r.Id == Id);
        }

        public Tuple<bool, string> Update(Flow flow)
        {
            if (!string.IsNullOrWhiteSpace(flow.Name))
            {
                if (db.Flow.Any(r => r.Id == flow.Id))
                {
                    var result = flow.Update() > 0;
                    return Tuple.Create(result, result ? "" : "");
                }
                else
                    return Tuple.Create(false, "不存在此更改!");
            }
            else
                return Tuple.Create(false, "修改的名称不能为空");
        }
    }
}