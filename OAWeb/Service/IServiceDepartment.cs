using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{

    public interface IServiceDepartment
    {
        Tuple<bool, string> Add(Department department);

        Tuple<bool, string> Update(Department department);

        Tuple<bool, string> Delete(string Id);

        Department GetDepartmentById(string Id);

        IQueryable<Department> GetAllDepartment();
    }
}