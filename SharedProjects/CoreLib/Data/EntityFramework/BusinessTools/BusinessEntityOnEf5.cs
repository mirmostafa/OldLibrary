using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using Mohammad.Data.BusinessTools;

namespace Mohammad.Data.EntityFramework.BusinessTools
{
    public abstract class BusinessEntityOnEf5<TEntity, TDateContext, TBusinessEntity> : BusinessEntity<TEntity, TBusinessEntity>,
        IDisposable
        where TEntity : EntityObject, new()
        where TDateContext : ObjectContext
        where TBusinessEntity : BusinessEntity<TEntity, TBusinessEntity>, new()
    {
        protected abstract TDateContext DataContext { get; }

        protected override void DeleteCore(TEntity entity, bool submitChanges) { this.DataContext.DeleteEntity(entity, submitChanges); }
        protected override TEntity FillCore(TEntity entity) { throw new NotImplementedException(); }
        protected override TEntity GetNewCore() { return Activator.CreateInstance<TEntity>(); }
        protected override void InsertCore(TEntity entity, bool submitChanges) { this.DataContext.InsertEntity(entity, submitChanges); }
        protected override IEnumerable<TEntity> SelectCore() { return this.DataContext.GetAll<TEntity>(); }
        protected override void SaveChangesCore() { this.DataContext.SaveChanges(); }
        protected override void UpdateCore(TEntity entity, bool submitChanges) { this.DataContext.UpdateEntity(entity, submitChanges); }

        public void Dispose()
        {
            var dataContext = this.DataContext;
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}