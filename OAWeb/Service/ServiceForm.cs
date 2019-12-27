using OAWeb.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceForm : Container, IServiceForm
    {
        public Tuple<bool, string> AddForm(Form form)
        {
            if (!string.IsNullOrWhiteSpace(form.Name) && !string.IsNullOrWhiteSpace(form.Descript))
            {
                if (!db.Form.Any(r => r.Id == form.Id && r.Name == form.Name))
                {
                    var result = form.Insert() > 0;
                    return Tuple.Create(result, result ? "添加成功" : "添加失败");
                }
                else
                    return Tuple.Create(false, "已经存在此表单");
            }
            else
                return Tuple.Create(false, "名称、描述、内容不能为空");
        }

        public Tuple<bool, string> AddForm_Instance(Form_Instance form_Instance)
        {
            if (!string.IsNullOrWhiteSpace(form_Instance.FormId))
            {
                if (!db.Form_Instance.Any(r => r.Id == form_Instance.Id))
                {
                    var result = form_Instance.Insert() > 0;
                    return Tuple.Create(result, result ? "添加成功" : "添加失败");
                }
                else
                    return Tuple.Create(false, "此表单实例已经存在");
            }
            else
                return Tuple.Create(false, "对应的表单不能为空");
        }

        public Tuple<bool, string> DeleteForm(string Id)
        {
            var form = db.Form.FirstOrDefault(r => r.Id == Id);
            if (form != null)
            {
                var result = form.Delete() > 0;
                return Tuple.Create(result, result ? "" : "删除失败");
            }
            else
                return Tuple.Create(false, "此表单模板不存在");
        }

        public IQueryable<Form> GetAllForm()
        {
            return db.Form;
        }

        public IQueryable<Form_Instance> GetAllForm_Instance()
        {
            return db.Form_Instance;
        }

        public Form GetFormById(string Id)
        {
            return db.Form.FirstOrDefault(r => r.Id == Id);
        }

        public Form_Instance GetForm_InstanceByFormId(string formId)
        {
            return db.Form_Instance.FirstOrDefault(r => r.FormId == formId);
        }

        public Form_Instance GetForm_InstanceById(string Id)
        {
            return db.Form_Instance.FirstOrDefault(r => r.Id == r.Id);
        }

        public Tuple<bool, string> UpdateForm(Form form)
        {
            if (!string.IsNullOrWhiteSpace(form.Name) && string.IsNullOrWhiteSpace(form.Descript))
            {
                if (db.Form.Any(r => r.Id == form.Id))
                {
                    var result = form.Update(r => r.Content, r => r.Parse_Content) > 0;
                    return Tuple.Create(result, result ? " " : "修改成功");
                }
            }
            return Tuple.Create(false, "名称和描述不能为空");
        }

        public Tuple<bool, string> UpdateForm_Instance(Form_Instance form_Instance)
        {
            if (!string.IsNullOrWhiteSpace(form_Instance.FormId))
            {
                if (db.Form_Instance.Any(r => r.Id == form_Instance.Id))
                {
                    var result = form_Instance.Update() > 0;
                    return Tuple.Create(result, result ? " " : "修改成功");
                }
            }
            return Tuple.Create(false, "表单不能为空");
        }
    }
}