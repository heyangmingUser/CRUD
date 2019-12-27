using OAWeb.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAWeb.Service
{
    public interface IServiceField
    {
        Tuple<bool, string> AddComponent(Component component);

        Tuple<bool, string> DeleteComponent(string Id);

        Tuple<bool, string> UpdateComponent(Component component);

        Tuple<bool, string> AddField(Field field);

        Tuple<bool, string> DeleteField(string Id);

        Tuple<bool, string> UpdateField(Field field);

        Tuple<bool, string> AddField_Instance(Field_Instance field_Instance);

        Tuple<bool, string> DeleteField_Instance(string Id);

        Tuple<bool, string> UpdateField_Instance(Field_Instance field_Instance);

        IQueryable<Field_Instance> GetAllField_Instance();

        IQueryable<Component> GetAllComponent();

        IQueryable<Field> GetAllField();

        Field GetFieldByComponentId(string componentId);

        Component GetComponentById(string id);

        Field GetFieldById(string Id);

        Field_Instance GetFile_InstanceById(string Id);
    }
}
