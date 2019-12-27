using OAWeb.Models.FlowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceNode
    {
        Tuple<bool, string> Add(Node node);

        Tuple<bool, string> Delete(string Id);

        Tuple<bool, string> Update(Node node);

        IQueryable<Node> GetAllNode();

        IQueryable<Node> GetNodeByFlowId(string flowId);

        Node GetNodeById(string Id);
    }
}