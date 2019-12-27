using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceDepartement : Container, IServiceDepartment
    {
        public Tuple<bool, string> Add(Department department)
        {
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                if (!db.Department.Any(r => r.Id == department.Id && r.Name == department.Name))
                {
                    var result = department.Insert() > 0;
                    return Tuple.Create(result, result ? "添加部门成功" : "添加部门失败");
                }
                return Tuple.Create(false, "此部门已经存在!");
            }
            else
                return Tuple.Create(false, "部门名称不能为空");
        }

        public Tuple<bool, string> Delete(string Id)
        {
            var department = db.Department.FirstOrDefault(r => r.Id == Id);
            if (department != null)
            {
                var result = department.Delete() > 0;
                return Tuple.Create(result, result ? "删除成功" : "删除失败");
            }
            else
                return Tuple.Create(false, "此部门不存在");

        }

        public IQueryable<Department> GetAllDepartment()
        {
            return db.Department;
        }

        public Department GetDepartmentById(string Id)
        {
            return db.Department.FirstOrDefault(r => r.Id == Id);
        }

        public Tuple<bool, string> Update(Department department)
        {
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                if (db.Department.Any(r => r.Id == department.Id))
                {
                    var result = department.Update() > 0;
                    return Tuple.Create(result, result ? "修改成功" : "修改失败");
                }
                return Tuple.Create(false, "不存在允许修改的部门！");
            }
            else
                return Tuple.Create(false, "修改名不能为空！");

        }
    }
}