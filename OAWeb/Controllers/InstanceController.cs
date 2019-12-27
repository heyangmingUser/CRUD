using OAWeb.Models.FlowModel;
using OAWeb.Models.FormModel;
using OAWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace OAWeb.Controllers
{
    public class InstanceController : ApiController
    {
        private IServiceNode ServiceNode = new ServiceNode();

        private IServiceflowInstance ServiceFlowInstance = new ServiceflowInstance();

        private IServiceForm ServiceForm = new ServiceForm();


        /// <summary>
        ///创建流程实例,即添加各个实例数据
        /// </summary>
        /// <returns></returns>
        public ActionResult AddFlow_Instance()
        {
            return View(new Flow_Instance());
        }
        [HttpPost]
        public ActionResult AddFlow_Instance(Flow_Instance flow_Instance)
        {
            //流程实例对应的流程的模板和发起流程的用户不为空
            if (!string.IsNullOrWhiteSpace(flow_Instance.FlowId) && !string.IsNullOrWhiteSpace(flow_Instance.UserId) && string.IsNullOrWhiteSpace(flow_Instance.FormId))
            {
                //找到流程模板对应的节点的集合
                var nodes = ServiceNode.GetNodeByFlowId(flow_Instance.FlowId);
                //找到此模板对应的第一个节点
                var node = nodes.FirstOrDefault(r => r.StepType == StepType.FirstStep);

                if (node != null)
                {
                    //1.创建流程实例的同时创建表单实例
                    var resultFlow_Instance = ServiceFlowInstance.AddFlowInstance(flow_Instance);
                    if (resultFlow_Instance.Item1)
                    {
                        //添加表单实例
                        Form_Instance form_Instance = new Form_Instance();
                        form_Instance.FormId = flow_Instance.FormId;
                        if (!string.IsNullOrWhiteSpace(form_Instance.FormId))
                        {
                            var resultForm = ServiceForm.AddForm_Instance(form_Instance);
                            if (resultForm.Item1)
                            {
                                FlowActionTraceData flowActionTraceData = new FlowActionTraceData()
                                {
                                    Flow_InstanceId = flow_Instance.Id,
                                    Form_InstanceId = form_Instance.Id
                                };
                                //流程实例和表单实例产生关联
                                var resultflowActionTraceData = ServiceFlowInstance.AddFlowActionTraceData(flowActionTraceData);
                                if (resultflowActionTraceData.Item1)
                                {
                                    ViewBag.Ok = true;
                                }

                            }

                        }
                    }
                    if (node == null)
                    {
                        node = nodes.FirstOrDefault(r => r.StepType == StepType.Normal);
                        if (node != null)
                        {
                        }
                        if (node == null)
                        {
                            node = nodes.FirstOrDefault(r => r.StepType == StepType.EndStep);
                            if (node != null)
                            {

                            }
                        }

                    }
                }

                else
                    ModelState.AddModelError(string.Empty, "流程未定义发起节点");
            }
            else
                ModelState.AddModelError(string.Empty, "创建流程实例时,流程模板和创建用户不能为空");
            return View();
        }

        /// <summary>
        /// 发起流程
        /// </summary>
        /// <returns></returns>

        public object StartFlow(string flow_InstanceId)
        {
            var flow_Instance = ServiceFlowInstance.GetFlow_InstancById(flow_InstanceId);
        }
        /// <summary>
        /// 添加表单实例
        /// </summary>
        /// <returns></returns>
        public ActionResult AddForm_Instance()
        {
            ViewBag.Form = ServiceForm.GetAllForm();
            return View();
        }
        [HttpPost]
        public object AddForm_Instance(Flow)
        {
            ViewBag.Form = ServiceForm.GetAllForm();

            if (!string.IsNullOrWhiteSpace(form_Instance.FormId))
            {
                var result = ServiceForm.AddForm_Instance(form_Instance);
                if (result.Item1)
                {
                    
                }
                else
                    ModelState.AddModelError(string.Empty, result.Item2);
            }
            else
                ModelState.AddModelError(string.Empty, "表单不能为空");
            return View();
        }

    }
}