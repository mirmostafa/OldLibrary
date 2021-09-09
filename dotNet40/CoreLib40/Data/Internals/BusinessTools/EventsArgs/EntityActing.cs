#region File Notice
// Created at: 2013/12/24 3:43 PM
// Last Update time: 2013/12/24 4:03 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System.Collections.Generic;
using Library40.EventsArgs;

namespace Library40.Data.Internals.BusinessTools.EventsArgs
{
	public class EntityActed<TEntity> : ItemActedEventArgs<TEntity>
	{
		// Methods
		public EntityActed(TEntity item)
			: base(item)
		{
		}
	}

	public class EntityActing<TEntity> : ItemActingEventArgs<TEntity>
	{
		// Methods
		public EntityActing(TEntity item)
			: base(item)
		{
		}
	}

	public enum EntityAction
	{
		Insert,
		Update,
		Delete
	}

	public class EntityValidated<TEntity> : ItemActedEventArgs<TEntity>
	{
		// Methods
		public EntityValidated(TEntity item, EntityAction action)
			: base(item)
		{
			this.Action = action;
		}

		// Properties
		public EntityAction Action { get; private set; }
	}

	public class EntityValidating<TEntity> : ItemActingEventArgs<TEntity>
	{
		// Methods
		public EntityValidating(TEntity item, EntityAction action)
			: base(item)
		{
			this.Action = action;
		}

		// Properties
		public EntityAction Action { get; private set; }
	}

	public class EntityValidatingByIds : ItemActingEventArgs<IEnumerable<long>>
	{
		// Methods
		public EntityValidatingByIds(IEnumerable<long> items, EntityAction action)
			: base(items)
		{
			this.Action = action;
		}

		// Properties
		public EntityAction Action { get; private set; }
	}
}