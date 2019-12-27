using OAWeb.Models.FlowModel;
using OAWeb.Models.FormModel;
using OAWeb.Models.UserRelation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OAWeb.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BaseContext:DbContext
    {
        public BaseContext() : base("BaseContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Permission> Permission { get; set; }

        public DbSet<Component> Component { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<Field_Instance> Field_Instance { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Form_Instance> Form_Instance { get; set; }

        public DbSet<Flow> Flow { get; set; }
        public DbSet<Flow_Instance> Flow_Instance { get; set; }
        public DbSet<Node> Node { get; set; }
        public DbSet<Node_Instance> Node_Instance { get; set; }
        public DbSet<FlowAction> FlowAction { get; set; }
        public DbSet<FlowAction_Instance> FlowAction_Instance { get; set; }
        public DbSet<FlowActionTraceData> FlowActionTraceData { get; set; }
    }
}