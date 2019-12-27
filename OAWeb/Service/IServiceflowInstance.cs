using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceflowInstance
    {
        Tuple<bool, string> AddNodeInstance(Node_Instance node_Instance);

        Tuple<bool, string> AddFlowInstance(Flow_Instance flow_Instance);

        Tuple<bool, string> AddFlowActionInstance(FlowAction_Instance flowAction_Instance);

        Tuple<bool, string> AddFlowActionTraceData(FlowActionTraceData flowActionTraceData);


        Tuple<bool, string> UpdateNodeInstance(Node_Instance node_Instance);

        Tuple<bool, string> UpdateFlowInstance(Flow_Instance flow_Instance);

        Tuple<bool, string> UpdateFlowActionInstance(FlowAction_Instance flowAction_Instance);

        Tuple<bool, string> UpdateFlowActionTraceData(FlowActionTraceData flowActionTraceData);


        IQueryable<Node_Instance> GetAllNode_Instance();

        IQueryable<Flow_Instance> GetAllFlow_Instance();

        IQueryable<FlowAction_Instance> GetAllFlowAction_Instance();

        IQueryable<FlowActionTraceData> GetAllFlowTraceData();


        Node_Instance GetNode_InstanceById(string Id);

        Flow_Instance GetFlow_InstancById(string Id);

        FlowAction_Instance GetFlowAction_InstanceById(string Id);

        FlowActionTraceData GetFlowActionTraceDataById(string Id);
    }
}