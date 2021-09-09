using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using Mohammad.DesignPatterns.ExceptionHandlingPattern;

namespace Mohammad.Data.EntityFramework
{
    public static class EntityFrameworkHelper
    {
        private static ExceptionHandling<Exception> _ExceptionHandling;

        public static ExceptionHandling<Exception> ExceptionHandling
        {
            get => _ExceptionHandling ?? (_ExceptionHandling = new ExceptionHandling<Exception>());
            set => _ExceptionHandling = value;
        }

        public static bool CanRequestNotifications()
        {
            try
            {
                new SqlClientPermission(PermissionState.Unrestricted).Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteEntity<TEntity>(this ObjectContext db, TEntity entity, bool submitChanges = true) where TEntity : class
        {
            ExceptionHandling.Reset();
            try
            {
                try
                {
                    db.CreateObjectSet<TEntity>().Attach(entity);
                }
                catch {}
                db.Refresh(RefreshMode.ClientWins, entity);
                db.CreateObjectSet<TEntity>().DeleteObject(entity);
                if (submitChanges)
                    db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        public static ObjectSet<TEntity> GetAll<TEntity>(this ObjectContext db) where TEntity : class
        {
            ExceptionHandling.Reset();
            try
            {
                return db.CreateObjectSet<TEntity>();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
                return null;
            }
        }

        public static void InsertEntity<TEntity>(this ObjectContext db, TEntity entity, bool submitChanges = true) where TEntity : class
        {
            ExceptionHandling.Reset();
            try
            {
                db.CreateObjectSet<TEntity>().AddObject(entity);
                if (submitChanges)
                    db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        public static void UpdateEntity<TEntity>(this ObjectContext db, TEntity entity, bool submitChanges = true) where TEntity : class
        {
            ExceptionHandling.Reset();
            try
            {
                try
                {
                    db.CreateObjectSet<TEntity>().Attach(entity);
                }
                catch {}
                db.Refresh(RefreshMode.ClientWins, entity);
                if (submitChanges)
                    db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        public static string GetTableName<TEntityObject>() where TEntityObject : EntityObject
        {
            var edmEntityType = typeof(TEntityObject).GetCustomAttributes(typeof(EdmEntityTypeAttribute), false).FirstOrDefault() as EdmEntityTypeAttribute;
            return edmEntityType != null ? edmEntityType.Name : string.Empty;
        }
    }
}