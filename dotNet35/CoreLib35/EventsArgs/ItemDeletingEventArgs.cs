#region File Notice
// Created at: 2013/12/24 3:41 PM
// Last Update time: 2013/12/24 3:58 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;

namespace Library35.EventsArgs
{
	public sealed class ItemDeletingEventArgs<TItem> : EventArgs
	{
		public ItemDeletingEventArgs(TItem item)
		{
			this.Item = item;
		}

		public bool Canceled { get; set; }

		public TItem Item { get; private set; }
	}
}