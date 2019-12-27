using OAWeb.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceForm
    {
        Tuple<bool, string> AddForm(Form form);

        Tuple<bool, string> DeleteForm(string Id);

        Tuple<bool, string> UpdateForm(Form form);

        Tuple<bool, string> AddForm_Instance(Form_Instance form_Instance);

        Tuple<bool, string> UpdateForm_Instance(Form_Instance form_Instance);

        IQueryable<Form_Instance> GetAllForm_Instance();

        IQueryable<Form> GetAllForm();

        Form GetFormById(string Id);

        Form_Instance GetForm_InstanceById(string Id);

        Form_Instance GetForm_InstanceByFormId(string formId);

    }
}