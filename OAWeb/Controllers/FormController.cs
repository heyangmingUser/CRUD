using OAWeb.Models;
using OAWeb.Models.FormModel;
using OAWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace OAWeb.Controllers
{
    public class FormController : Controller
    {
        private IServiceForm ServiceForm = new ServiceForm();
        private IServiceField ServiceField = new ServiceField();


        public ActionResult FormIndex()
        {
            List<Form> list = new List<Form>();
            var formdata = ServiceForm.GetAllForm().ToList();
            var formpage = Math.Ceiling((decimal)formdata.Count / 10);
            for (int page = 1; page <= formpage; page++)
            {
                var forms = formdata.Skip((Math.Max(0, page - 1) * 10)).Take(10).ToList();
                list.AddRange(forms);
            }
            ViewBag.Forms = list;
            return View();

        }
        /// <summary>
        /// 利用设计器设计的模板来保存信息,首次从表单设计器中获取到的只有Content,再次获取的时候是获取解析之后的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveDesigner()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveDesigner(HtmlModel htmlmodel)
        {
            ViewBag.Form = ServiceForm.GetAllForm();
            var form = ServiceForm.GetFormById(htmlmodel.FormId);
            if (form != null)
            {
                form.Content = htmlmodel.HtmlContent;
                var result = ServiceForm.UpdateForm(form);
                if (result.Item1)
                {
                    ViewBag.Ok = true;
                }
                else
                    ModelState.AddModelError(string.Empty, result.Item2);
            }
            //解析设计器的数据保存到作为HTML的格式文件存储
            #region


            #region /*匹配单个文本框*/
            //Regex reginput = new Regex("<input[^<>]+/>", RegexOptions.Compiled);//可以匹配所有的input标签
            Regex reginput = new Regex("<input name=\"leipiNewField\" type=\"(?<type>.*?)\" title=\"(?<title>.*?)\".*?/>", RegexOptions.Compiled);
            MatchCollection matchCollectinput = reginput.Matches(htmlmodel.HtmlContent);
            if (matchCollectinput.Count > 0)
            {
                foreach (Match match in matchCollectinput)
                {
                    Component component = new Component();
                    var title = match.Groups["title"].Value;
                    var type = match.Groups["type"].Value;
                    component.Name = title;
                    component.Type = type;
                    var componentResult = ServiceField.AddComponent(component);
                    if (componentResult.Item1)
                    {
                        Field field = new Field();
                        //标签
                        field.ComponentId = component.Id;
                        field.FormId = htmlmodel.FormId;
                        var fieldResult = ServiceField.AddField(field);
                        if (fieldResult.Item1)
                        {
                            form.Parse_Content = htmlmodel.HtmlContent.Replace(match.Value, $"#{title}#");

                            ServiceForm.UpdateForm(form);

                        }
                        else
                            ModelState.AddModelError(string.Empty, fieldResult.Item2);
                    }
                    else

                        ModelState.AddModelError(string.Empty, componentResult.Item2);



                }
            }
            #endregion

            #region 匹配input作为子标签
            /*匹配input作为子标签*/
            //Regex reginput1 = new Regex("(<input name=\"(?<name>leipiNewField)\" value=\"(?<Value>.*?)\" type=\"(?<type>.*?)\"/>).*?", RegexOptions.Compiled);
            //MatchCollection matchCollectinput1 = reginput1.Matches(htmlModel.Design_content);
            //if (matchCollectinput1.Count > 0)
            //{
            //    foreach (Match match in matchCollectinput1)
            //    {
            //        var title = match.Groups["name"].Value;
            //        var type = match.Groups["type"].Value;
            //        var Value = match.Groups["Value"].Value;
            //        propertyModel.Name = title;
            //        propertyModel.Type = type;
            //        propertyModel.Value = Value;
            //        htmlModel.Design_content = htmlModel.Design_content.Replace(match.Value, $"#{title}#");

            //        //提取字段值之后进行字段存储--暂时未加(add)

            //    }
            //}
            #endregion

            #region/*匹配文本框*/
            Regex regintextarea = new Regex("<textarea.*?title=\"(?<title>.*?)\".*?leipiplugins=\"(?<type>.*?)\".*?>.*?</textarea>", RegexOptions.Compiled);
            MatchCollection matchCollectiontextarea = regintextarea.Matches(htmlmodel.HtmlContent);
            if (matchCollectiontextarea.Count > 0)
            {
                foreach (Match match in matchCollectiontextarea)
                {
                    Component component = new Component();
                    var title = match.Groups["title"].Value;
                    var type = match.Groups["type"].Value;
                    component.Name = title;
                    component.Type = type;
                    var componentResult = ServiceField.AddComponent(component);

                    if (componentResult.Item1)
                    {
                        Field field = new Field();
                        field.ComponentId = component.Id;
                        field.FormId = htmlmodel.FormId;
                        var fieldResult = ServiceField.AddField(field);
                        if (fieldResult.Item1)
                        {
                            form.Parse_Content = htmlmodel.HtmlContent.Replace(match.Value, $"#{title}#");

                            ServiceForm.UpdateForm(form);
                        }
                        else
                            ModelState.AddModelError(string.Empty, fieldResult.Item2);
                    }
                    else
                        ModelState.AddModelError(string.Empty, componentResult.Item2);
                }
            }
            #endregion

            #region/*匹配下拉,单选,复选*/
            Regex reginT = new Regex("<span\\sleipiplugins=\"(?<leipiplugins>.*?)\".*?title=\"(?<title>.*?)\".*?>.*?</span>", RegexOptions.Compiled);
            MatchCollection matchCollectionT = reginT.Matches(htmlmodel.HtmlContent);
            if (matchCollectionT.Count > 0)
            {
                foreach (Match match in matchCollectionT)
                {
                    var title = match.Groups["title"].Value;
                    var leipiplugins = match.Groups["leipiplugins"].Value.TrimEnd('s');
                    if (leipiplugins == "radio" || leipiplugins == "checkbox")
                    {
                        Regex subRegex = new Regex("(<input name=\"leipiNewField\" value=\"(?<Value>.*?)\" type=\"(.*?)\"/>).*?", RegexOptions.Compiled);
                        MatchCollection submatch = subRegex.Matches(match.Value);
                        foreach (Match match1 in submatch)
                        {
                            Component component = new Component();
                            var Value = match1.Groups["Value"].Value;
                            component.Name = title;
                            component.Type = leipiplugins;
                            var compentResult = ServiceField.AddComponent(component);
                            if (compentResult.Item1)
                            {
                                Field field = new Field();
                                field.Value = Value;
                                field.ComponentId = component.Id;
                                field.FormId = htmlmodel.FormId;
                                var fieldResult = ServiceField.AddField(field);
                                if (fieldResult.Item1)
                                {

                                }
                                else
                                    ModelState.AddModelError(string.Empty, fieldResult.Item2);
                            }
                            else
                                ModelState.AddModelError(string.Empty, compentResult.Item2);

                        }
                    }
                    else if (leipiplugins == "select")
                    {
                        Regex subRegex1 = new Regex("(<option value=\"(?<Value>.*?)\">).*?", RegexOptions.Compiled);
                        MatchCollection submatch1 = subRegex1.Matches(match.Value);
                        foreach (Match match2 in submatch1)
                        {
                            Component component = new Component();
                            var Value = match2.Groups["Value"].Value;
                            component.Name = title;
                            component.Type = leipiplugins;
                            var componentResult = ServiceField.AddComponent(component);
                            if (componentResult.Item1)
                            {
                                Field field = new Field();
                                field.ComponentId = component.Id;
                                field.Value = Value;
                                field.FormId = htmlmodel.FormId;
                                var fieldResult = ServiceField.AddField(field);
                                if (fieldResult.Item1)
                                {

                                }
                                else
                                    ModelState.AddModelError(string.Empty, fieldResult.Item2);
                            }
                            else
                                ModelState.AddModelError(string.Empty, componentResult.Item2);


                        }
                    }
                    form.Parse_Content = htmlmodel.HtmlContent.Replace(match.Value, $"#{title}#");
                    ServiceForm.UpdateForm(form);

                }
            }
            #endregion
            return View();
            #endregion

        }

        /// <summary>
        /// 实时预览，此预览是在设计器中预览的模式
        /// </summary>
        /// <param name="htmlModel"></param>
        /// <returns></returns>
        public ActionResult LivePreview(HtmlModel htmlModel)
        {
            ViewBag.Html = htmlModel.HtmlContent;

            return View();
        }

        /// <summary>
        /// 保存预览，在模板生成后，使用者可以通过此模式进行对应模板的查询,已经是保存下来的HTML模板
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult SavePreview(Form form)
        {
            ViewBag.Form = form.Content;

            return View();
        }


        /// <summary>
        /// 添加表单模板信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddForm()
        {
            return View(new Form());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddForm(Form form)
        {
            //第一次添加表单模板时，只添加姓名和描述性这两个属性
            if (!string.IsNullOrWhiteSpace(form.Descript) && !string.IsNullOrWhiteSpace(form.Name))
            {
                var result = ServiceForm.AddForm(form);
                if (result.Item1)
                {
                    ViewBag.Ok = true;
                    return View();
                }
                throw new Exception(result.Item2);
            }
            else
                ModelState.AddModelError(string.Empty, "数据不能为空");
            return View(form);
        }
    }
}