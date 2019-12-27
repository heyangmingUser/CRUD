using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Service
{
    public interface IServiceRole
    {
        Tuple<bool, string> Add(Role role);

        Tuple<bool, string> Update(Role role);

        Tuple<bool, string> Delete(string role);
    }
}