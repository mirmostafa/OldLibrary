using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using Mohammad.DesignPatterns.ExceptionHandlingPattern;

namespace Mohammad.Helpers
{
    public static class LinqHelper
    {
        public static ConflictMode? DefaultConflictMode = null;
        public static SqlDataReader AsDataReader(this DataContext db, IQueryable query) { return query.AsDataReader(db); }

        public static SqlDataReader AsDataReader(this IQueryable query, DataContext db)
        {
            using (var command = query.AsSqlCommand(db))
            {
                command.Connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static SqlCommand AsSqlCommand(this IQueryable query, DataContext db) { return db.GetCommand(query) as SqlCommand; }

        public static bool CanRequestNotifications()
        {
            return CodeHelper.Catch(() =>
                {
                    new SqlClientPermission(PermissionState.Unrestricted).Demand();
                    return true;
                },
                ex => false);
        }

        public static void DeleteEntity<TEntity>(this DataContext db, TEntity entity, bool submitChanges = true, ExceptionHandling exceptionHandling = null)
            where TEntity : class
        {
            CodeHelper.Catch(() =>
                {
                    CodeHelper.Catch(() => db.GetTable<TEntity>().Attach(entity, false));
                    db.Refresh(RefreshMode.KeepCurrentValues, entity);
                    db.GetTable<TEntity>().DeleteOnSubmit(entity);
                    if (submitChanges)
                        db.SubmitChanges();
                },
                exceptionHandling,
                true);
        }

        public static Table<TEntity> GetAll<TEntity>(this DataContext db, ExceptionHandling exceptionHandling) where TEntity : class
        {
            return CodeHelper.Catch(db.GetTable<TEntity>, exceptionHandling, true);
        }

        public static string GetSqlStatement(this IQueryable query, DataContext db) { return db.GetCommand(query).CommandText; }

        public static void InsertEntity<TEntity>(this DataContext db, TEntity entity, bool submitChanges = true, ExceptionHandling exceptionHandling = null)
            where TEntity : class
        {
            CodeHelper.Catch(() =>
                {
                    db.GetTable<TEntity>().InsertOnSubmit(entity);
                    if (submitChanges)
                        db.SaveChanges();
                },
                exceptionHandling,
                true);
        }

        private static void SaveChanges(this DataContext db, ConflictMode? failureMode = null)
        {
            if (failureMode.HasValue)
            {
                db.SubmitChanges(failureMode.Value);
            }
            else
            {
                if (DefaultConflictMode.HasValue)
                    db.SubmitChanges(DefaultConflictMode.Value);
                else
                    db.SubmitChanges();
            }
        }

        public static DataTable ToDataTable(this IQueryable query, DataContext db)
        {
            var result = new DataTable();
            result.Load(query.AsDataReader(db));
            return result;
        }

        public static void UpdateEntity<TEntity>(this DataContext db, TEntity entity, bool submitChanges = true, ExceptionHandling exceptionHandling = null)
            where TEntity : class
        {
            lock (db)
            {
                CodeHelper.Catch(() => Attach(db, entity));
                CodeHelper.Catch(() =>
                    {
                        db.Refresh(RefreshMode.KeepCurrentValues, entity);
                        if (submitChanges)
                            db.SubmitChanges();
                    },
                    exceptionHandling,
                    true);
            }
        }

        public static void Attach<TEntity>(this DataContext db, TEntity entity, bool asModified = true) where TEntity : class
        {
            db.GetTable<TEntity>().Attach(entity, asModified);
        }

        public static void Attach<TEntity>(this DataContext db, TEntity entity, TEntity original) where TEntity : class
        {
            db.GetTable<TEntity>().Attach(entity, original);
        }
    }
}