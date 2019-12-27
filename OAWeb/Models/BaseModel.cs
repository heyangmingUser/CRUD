using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAWeb.Models
{
    public abstract class BaseModel
    {
        private string _id = string.Empty;
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    _id = System.Guid.NewGuid().ToString();
                }
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}