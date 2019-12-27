using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceFlow
    {
        Tuple<bool, string> Add(Flow flow);

        Tuple<bool, string> Delete(string Id);

        Tuple<bool, string> Update(Flow flow);

        IQueryable<Flow> GetAllFlow();

        Flow GetFlowById(string Id);

        Flow GetFlowByFlowInstanceId(string Flow_InstanceId);

    }
}