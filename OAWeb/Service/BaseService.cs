using OAWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OAWeb.Service
{
    //数据的删除、添加和修改暂未做修改
    public static class BaseService
    {

        public static int Insert<T>(this T entity) where T : BaseModel, new()
        {

            var db = Container.GetBaseContext();
            //entry获取实体的代理类
            db.Entry(entity).State = EntityState.Added;
            return db.SaveChanges();

        }

        public static int Update<T>(this T entity) where T : BaseModel, new()
        {

            var db = Container.GetBaseContext();
            //set结果返回实体类
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public static int Update<T>(this T entity, params Expression<Func<T, object>>[] updatedProperties) where T : BaseModel, new()
        {
            var db = Container.GetBaseContext();
            //获取实体对象的代理类
            var dbEntityEntry = db.Entry(entity);
            if (updatedProperties.Any())
            {
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                    {
                        dbEntityEntry.Property(property).IsModified = true;
                    }
                }
            }
            return db.SaveChanges();
        }

        public static int Delete<T>(this T entity) where T : BaseModel, new()
        {

            var db = Container.GetBaseContext();
            //attach将实体附加到上下文当中，进行操作
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges();
        }

    }

    public abstract class Container
    {

        public static BaseContext GetBaseContext()
        {
            BaseContext db = null;
            if (db == null)
            {
                db = new BaseContext();
            }
            return db;
        }

        public static BaseContext db
        {
            get { return GetBaseContext(); }
        }
    }
}