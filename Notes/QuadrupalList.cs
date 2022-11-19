using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	public class QuadrupalList<T, I, A, V> : IEnumerable<T>
	{
		dynamic[] Items;
		T[] types;
		I[] identifiers;
		A[] actions;
		V[] values;

		public int Count { get { return Items.Length; } }

		public QuadrupalList(int capacity = 0)
		{
			Items = new dynamic[capacity];
		}

		public void Add(T type, I identifier, A action, V value)
		{
			ResizeAndReorderArray();
			Items[Count - 1] = new dynamic[]
			{
				type,
				identifier,
				action,
				value
			};
		}

		private void ResizeAndReorderArray()
		{
			// Create a new array with 1 extra space.
			dynamic[] array = new dynamic[Count + 1];

			for (int index = 0; index < Count; index++)
			{
				array[index] = Items[index];
			}

			Items = array;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			foreach (T item in Items)
			{
				yield return item;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}
}
