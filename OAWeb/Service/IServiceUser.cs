using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceUser
    {
        Tuple<bool, string> Add(User user);

        Tuple<bool, string> Update(User user);

        Tuple<bool, string> Delete(string Id);

        User GetUserById(string Id);

        IQueryable<User> GetAllUser();

        IQueryable<User> GetUsersByDepartmentId(string DepartmentId);

    }
}