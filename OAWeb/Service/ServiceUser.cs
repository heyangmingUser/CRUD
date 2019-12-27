using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public class ServiceUser : Container, IServiceUser
    {
        public Tuple<bool, string> Add(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Tel))
            {
                if (!string.IsNullOrWhiteSpace(user.DepartmentId) && !string.IsNullOrWhiteSpace(user.RoleId))
                {
                    if (!db.User.Any(r => r.Id == user.Id && r.Tel == user.Tel))
                    {
                        var result = user.Insert() > 0;
                        return Tuple.Create(result, result ? "添加用户成功" : "添加用户失败");
                    }
                    return Tuple.Create(false, "此用户已经存在!");
                }
                return Tuple.Create(false, "用户所属角色和部门不能为空");
            }
            else
                return Tuple.Create(false, "用户名称、邮件、电话不能为空");
        }

        public Tuple<bool, string> Delete(string Id)
        {
            var user = db.User.FirstOrDefault(r => r.Id == Id);
            if (user != null)
            {
                var result = user.Delete() > 0;
                return Tuple.Create(result, result ? "删除成功" : "删除失败");
            }
            else
                return Tuple.Create(false, "此用户不存在");

        }

        public IQueryable<User> GetAllUser()
        {
            return db.User;
        }

        public User GetUserById(string Id)
        {
            return db.User.FirstOrDefault(r => r.Id == Id);
        }

        public IQueryable<User> GetUsersByDepartmentId(string DepartmentId)
        {
            return db.User.Where(r => r.DepartmentId == DepartmentId);
        }

        public Tuple<bool, string> Update(User user)
        {
            if (db.User.Any(r => r.Id == user.Id))
            {
                var result = user.Update() > 0;
                return Tuple.Create(result, result ? "修改成功" : "修改失败");
            }
            return Tuple.Create(false, "不存在允许修改的部门！");
        }
    }
}