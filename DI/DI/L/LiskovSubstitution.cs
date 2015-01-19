using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// функции которые используют ссылки на базовые классы, 
// должны иметь возможномть использовать объекты производных классов, не зная об этом

// неправильно
namespace LiskovSubstitution
{
	public class DoubleList<T> : IList<T>
	{
		private readonly IList<T> innerList = new List<T>();
		public void Add(T item)
		{
			innerList.Add(item);
			innerList.Add(item);
		}

		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public T this[int index]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}


		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}

// правильно
namespace LiskovSubstitution2
{
	public interface IDoubleList<T>
	{
		void Add(T item);
	}

	public class DoubleList<T> : IDoubleList<T>
	{
		private readonly IList<T> innerList = new List<T>();
		public void Add(T item)
		{
			innerList.Add(item);
			innerList.Add(item);
		}
	}
}