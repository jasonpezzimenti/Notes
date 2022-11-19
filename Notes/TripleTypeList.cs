using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	public class TripleTypeList<T, V, A> : IEnumerable<Tuple<T, V, A>>
	{
		dynamic[] Items;
		T Type;
		V Value;
		A Action;

		public TripleTypeList()
		{
			Items = new dynamic[0];
		}

		private dynamic[] ResizeArray()
		{
			dynamic[] array = new dynamic[Items.Length];

			for (int index = 0; index < Items.Length; index++)
			{
				array[index] = Items[index];
			}

			return array;
		}

		public void Add(T type, V value, A action)
		{
			ResizeArray();
			Items[Items.Length - 1] = new Tuple<T, V, A>(type, value, action);
		}

		public void RemoveAt(int index)
		{
			Items = Items.Where((value, i) => i != index).ToArray();
		}

		IEnumerator<Tuple<T, V, A>> IEnumerable<Tuple<T, V, A>>.GetEnumerator()
		{
			foreach(dynamic item in Items)
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
