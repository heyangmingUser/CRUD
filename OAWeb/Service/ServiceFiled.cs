using OAWeb.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceField : Container, IServiceField
    {

        public Tuple<bool, string> AddComponent(Component component)
        {
            if (!string.IsNullOrWhiteSpace(component.Name) && !string.IsNullOrWhiteSpace(component.Type))
            {
                if (!db.Component.Any(r => r.Id == component.Id))
                {
                    if (!db.Component.Any(r => r.Name == component.Name && r.Type == component.Type))
                    {
                        var result = component.Insert() > 0;
                        return Tuple.Create(result, result ? " 添加成功" : "添加控件失败");
                    }
                    else
                        return Tuple.Create(false, "名称和类型不能同时拥有相同的存在!");
                }
                else
                    return Tuple.Create(false, "已经存在此应用组件");
            }
            return Tuple.Create(false, "Name和Type不能为空");
        }

        public Tuple<bool, string> AddField(Field field)
        {
            if (string.IsNullOrWhiteSpace(field.ComponentId) && !string.IsNullOrWhiteSpace(field.FormId))
            {
                if (string.IsNullOrWhiteSpace(field.Label))
                {
                    if (!db.Field.Any(r => r.Id == field.Id && r.FormId == field.FormId && r.ComponentId == field.ComponentId))
                    {
                        var result = field.Insert() > 0;
                        return Tuple.Create(result, result ? "添加成功" : "添加字段失败");
                    }
                    return Tuple.Create(false, "此字段已经存在");
                }
                else
                    return Tuple.Create(false, "字段的标签不能为空!");
            }
            else
                return Tuple.Create(false, "字段对应的表单和组件不能为空!");
        }

        public Tuple<bool, string> AddField_Instance(Field_Instance field_Instance)
        {
            if (!string.IsNullOrWhiteSpace(field_Instance.FieldId) && string.IsNullOrWhiteSpace(field_Instance.Form_InstanceId))
            {
                if (!db.Field_Instance.Any(r => r.Id == field_Instance.Id))
                {
                    var result = field_Instance.Insert() > 0;
                    return Tuple.Create(result, result ? "添加成功" : "添加失败!");
                }
                else
                    return Tuple.Create(false, "相同的字段实例已经存在!");
            }
            else
                return Tuple.Create(false, "字段实例所关联的字段和表单实例不能为空");
        }

        public Tuple<bool, string> DeleteComponent(string Id)
        {
            var component = db.Component.FirstOrDefault(r => r.Id == Id);
            if (component != null)
            {
                var result = component.Delete() > 0;

                return Tuple.Create(result, result ? "删除成功" : "删除失败");

            }
            else
                return Tuple.Create(false, "控件已经删除或者不存在");
        }

        public Tuple<bool, string> DeleteField(string Id)
        {
            var field = db.Field.FirstOrDefault(r => r.Id == Id);
            if (field != null)
            {
                var result = field.Delete() > 0;

                return Tuple.Create(result, result ? "删除成功" : "删除失败");

            }
            else
                return Tuple.Create(false, "字段已经删除或者不存在");
        }

        public Tuple<bool, string> DeleteField_Instance(string Id)
        {
            var field_Instance = db.Field_Instance.FirstOrDefault(r => r.Id == Id);
            if (field_Instance != null)
            {
                var result = field_Instance.Delete() > 0;

                return Tuple.Create(result, result ? "删除成功" : "删除失败");

            }
            else
                return Tuple.Create(false, "字段实例已经删除或者不存在");
        }

        public IQueryable<Component> GetAllComponent()
        {
            return db.Component;
        }

        public IQueryable<Field> GetAllField()
        {
            return db.Field;
        }

        public IQueryable<Field_Instance> GetAllField_Instance()
        {
            return db.Field_Instance;
        }

        public Component GetComponentById(string id)
        {
            return db.Component.FirstOrDefault(r => r.Id == id);
        }

        public Field GetFieldByComponentId(string componentId)
        {
            return db.Field.FirstOrDefault(r => r.ComponentId == componentId);
        }

        public Field GetFieldById(string Id)
        {
            return db.Field.FirstOrDefault(r => r.Id == Id);
        }

        public Field_Instance GetFile_InstanceById(string Id)
        {
            return db.Field_Instance.FirstOrDefault(r => r.Id == Id);
        }

        public Tuple<bool, string> UpdateComponent(Component component)
        {
            if (!string.IsNullOrWhiteSpace(component.Name) && !string.IsNullOrWhiteSpace(component.Type))
            {
                if (db.Component.Any(r => r.Id == component.Id && r.Name != component.Name && r.Type != component.Type))
                {
                    var result = component.Update() > 0;
                    return Tuple.Create(result, result ? "修改成功" : "修改失败");
                }
                else
                    return Tuple.Create(false, "不存在修改的此条记录!");
            }
            else
                return Tuple.Create(false, "修改的名称和类型不能为空!");

        }

        public Tuple<bool, string> UpdateField(Field field)
        {
            if (db.Component.Any(r => r.Id == field.Id))
            {
                if (!string.IsNullOrWhiteSpace(field.ComponentId) && !string.IsNullOrWhiteSpace(field.FormId) && string.IsNullOrWhiteSpace(field.Label))
                {
                    var result = field.Update() > 0;
                    return Tuple.Create(result, result ? "修改成功" : "修改失败");
                }
                else
                    return Tuple.Create(false, "校验值不能为空!");
            }
            else
                return Tuple.Create(false, "不存在修改的此条记录!");
        }

        public Tuple<bool, string> UpdateField_Instance(Field_Instance field_Instance)
        {
            if (db.Field_Instance.Any(r => r.Id == field_Instance.Id && r.FieldId == field_Instance.FieldId && r.Form_InstanceId == field_Instance.Form_InstanceId))
            {
                var result = field_Instance.Update() > 0;
                return Tuple.Create(result, result ? "修改成功" : "修改失败");
            }
            else
                return Tuple.Create(false, "此条记录不不存在!");
        }
    }
}
