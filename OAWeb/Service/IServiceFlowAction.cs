using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceFlowAction
    {
        Tuple<bool, string> Add(FlowAction flowAction);

        Tuple<bool, string> Update(FlowAction flowAction);

        FlowAction GetFlowActionById(string Id);

        IQueryable<FlowAction> GetAllFlowAction();

        IQueryable<FlowAction> GetFlowActionsByNodeId(string Id);

    }
}