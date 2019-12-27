using OAWeb.Models.FlowModel;
using OAWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAWeb.Controllers
{

    public class FlowController : Controller
    {
        private IServiceFlow ServiceFlow = new ServiceFlow();

        private IServiceNode ServiceNode = new ServiceNode();

        private IServiceFlowAction ServiceFlowAction = new ServiceFlowAction();

        private IServiceflowInstance ServiceFlowInstance = new ServiceflowInstance();

        private IServiceForm ServiceForm = new ServiceForm();


        /// <summary>
        /// 添加流程模板
        /// </summary>
        /// <returns></returns>
        public ActionResult AddFlow()
        {
            return View(new Flow());
        }
        public ActionResult AddFlow(Flow flow)
        {
            if (!string.IsNullOrWhiteSpace(flow.Name))
            {
                var result = ServiceFlow.Add(flow);
                if (result.Item1)
                {
                    ViewBag.Ok = true;
                }
                else
                    ModelState.AddModelError(string.Empty, result.Item2);
            }
            ModelState.AddModelError(string.Empty, "流程的名称!");
            return View();
        }

        /// <summary>
        ///添加流程节点模型
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNode(string formId)
        {
            if (!string.IsNullOrWhiteSpace(formId))
            {
                ViewBag.Form = ServiceFlow.GetFlowById(formId);
            }
            return View();
        }
        public ActionResult AddNode(Node node)
        {
            ViewBag.Forms = ServiceFlow.GetAllFlow();
            if (!string.IsNullOrWhiteSpace(node.Name) && !string.IsNullOrWhiteSpace(node.FlowId))
            {
                if (node.StepType == StepType.FirstStep)
                {
                    node.PreNodeNumber = node.NodeNumber;
                    node.NextNodeNumber = node.NodeNumber + 1;
                }
                else if (node.StepType == StepType.EndStep)
                {
                    node.PreNodeNumber = node.NodeNumber - 1;
                    node.NextNodeNumber = node.NodeNumber;
                }
                else if (node.StepType == StepType.Normal)
                {
                    node.PreNodeNumber = node.NodeNumber - 1;
                    node.NextNodeNumber = node.NodeNumber + 1;
                }

                var result = ServiceNode.Add(node);
                if (result.Item1)
                {
                    ViewBag.Ok = true;
                }
                else
                    ModelState.AddModelError(string.Empty, result.Item2);
            }
            else
                ModelState.AddModelError(string.Empty, "节点名称、节点编号、节点所属流程");
            return View();
        }

        /// <summary>
        /// 添加节点所属的所有操作
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public ActionResult AddFlowAction(string nodeId)
        {
            if (!string.IsNullOrWhiteSpace(nodeId))
            {
                ViewBag.Node = ServiceNode.GetNodeById(nodeId);
            }
            return View();
        }
        public ActionResult AddFlowAction(FlowAction flowAction)
        {
            ViewBag.Nodes = ServiceNode.GetAllNode();
            if (!string.IsNullOrWhiteSpace(flowAction.NodeId) && !string.IsNullOrWhiteSpace(flowAction.Name))
            {
                var result = ServiceFlowAction.Add(flowAction);
                if (result.Item1)
                {
                    ViewBag.Ok = true;
                }
                else
                    ModelState.AddModelError(string.Empty, result.Item2);
            }
            else
                ModelState.AddModelError(string.Empty, "操作名称不能为空,操作所属的节点不能为空，操作所属的流程不能为空");
            return View();
        }
    }
}