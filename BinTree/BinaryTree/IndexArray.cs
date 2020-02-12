using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

	public class IndexArray<T> : IList<T>
	{
		IndexArrayElement<T> head;
		public int StartIndex { get; private set; }

		public IndexArray()
		{
			head = null;
			StartIndex = 0;
		}

		public IndexArray(int start)
		{
			StartIndex = start;
			head = null;
		}

		
		public IndexArray(T[] array)
		{
			StartIndex = 0;
			head = null;
			for (int i = 0; i < array.Length; i++)
			{
				Add(array[i]);
			}
		}

		public IndexArray(int start, T[] array)
		{
			StartIndex = start;
			head = null;
			for (int i = 0; i < array.Length; i++)
			{
				Add(array[i]);
			}
		}
		

		public T this[int index]
		{
			get
			{
				if (index < StartIndex || index >= Count + StartIndex)
					throw new IndexOutOfRangeException();
				int i = StartIndex;
				IndexArrayElement<T> temp = head;
				while (i != index)
				{
					temp = temp.Next;
					i++;
				}
				return temp.Value;
			}

			set
			{
				if (index < StartIndex || index >= Count + StartIndex)
					throw new IndexOutOfRangeException();
				int i = StartIndex;
				IndexArrayElement<T> temp = head;
				while (i != index)
				{
					temp = temp.Next;
					i++;
				}

				temp.Value = value;
			}
		}

		public int Count { get; private set; }

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			if (head == null) head = new IndexArrayElement<T>(item);
			else
			{
				IndexArrayElement<T> temp = head;
				while(temp.Next != null)
				{
					temp = temp.Next;
				}
				temp.Next = new IndexArrayElement<T>(item);
			}
			Count++;
		}

		public void Clear()
		{
			if (head == null) return;
			else
			{
				IndexArrayElement<T> temp = head;
				while (temp.Next != null)
				{
					temp = temp.Next;
				}
				temp = null;
				Count--;
			}
		}

		public bool Contains(T item)
		{
			if (item == null) throw new ArgumentNullException();
			IndexArrayElement<T> temp = head;
			while (temp != null)
			{
				if (temp.Value.Equals(item))
					return true;
				temp = temp.Next;
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("The array cannot be null.");
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
			if (Count > array.Length - arrayIndex + 1)
				throw new ArgumentException("The destination array has fewer elements than the collection.");

			IndexArrayElement<T> temp = head;
			int i = 0;
			while (temp != null)
			{
				array[i + arrayIndex] = temp.Value;
				temp = temp.Next;
			}
		}

		
		public int IndexOf(T item)
		{
			if (item == null) throw new ArgumentNullException();
			int index = StartIndex;
			IndexArrayElement<T> temp = head;
			while (temp != null)
			{
				if (temp.Value.Equals(item))
					return index;
				index++;
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			if (item == null) throw new ArgumentNullException();
			if (index < StartIndex || index >= Count + StartIndex)
				throw new IndexOutOfRangeException();
			int i = StartIndex;
			if(index == StartIndex)
			{
				IndexArrayElement<T> Element = new IndexArrayElement<T>(head.Value);
				Element.Next = head.Next;
				head.Value = item;
			}
			IndexArrayElement<T> temp = head;
			while (i != index)
			{
				temp = temp.Next;
				i++;
			} 

			IndexArrayElement<T> newElement = new IndexArrayElement<T>(item);
			newElement.Next = temp.Next;
			temp.Next = newElement;
		}

		public bool Remove(T item)
		{
			if (item == null) throw new ArgumentNullException();
			IndexArrayElement<T> temp = head;
			if (head.Value.Equals(item))
			{
				head = head.Next;
				Count--;
				return true;
			}
			while (!temp.Next.Value.Equals(item) && temp != null)
			{
				temp = temp.Next;
			}
			if (temp != null)
			{
				temp.Next = temp.Next.Next;
				Count--;
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			if (index < StartIndex || index >= Count + StartIndex)
				throw new IndexOutOfRangeException();
			int i = StartIndex;
			if (i == index)
			{
				head = head.Next;
				Count--;
				return;
			}

			IndexArrayElement<T> temp = head;
			while (i != index-1)
			{
				temp = temp.Next;
				i++;
			}

			temp.Next = temp.Next.Next;
			Count--;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new IndexArrayEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class IndexArrayEnumerator : IEnumerator<T>
		{
			private IndexArray<T> array;
			int position = -1;

			public IndexArrayEnumerator(IndexArray<T> array)
			{
				this.array = array;
				position = array.StartIndex - 1;
			}

			public object Current
			{
				get
				{
					if (position == array.StartIndex - 1 || position >= array.Count + array.StartIndex)
						throw new InvalidOperationException();
					return array[position];
				}
			}

			T IEnumerator<T>.Current => (T)Current;

			public void Dispose()
			{
			
			}

			public bool MoveNext()
			{
				if (position < array.Count + array.StartIndex - 1)
				{
					position++;
					return true;
				}
				else
					return false;
			}

			public void Reset()
			{
				position = array.StartIndex - 1;
			}
		}
	}

	[Serializable]
	internal class IndexArrayExeption : Exception
	{
		public IndexArrayExeption()
		{
		}

		public IndexArrayExeption(string message) : base(message)
		{
		}

		public IndexArrayExeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected IndexArrayExeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}


	internal class IndexArrayElement<T>
	{
		public T Value { get; set; }
		public IndexArrayElement<T> Next;

		public IndexArrayElement()
		{
			Value = default(T);
			Next = null;
		}
		public IndexArrayElement(T value)
		{
			this.Value = value;
			Next = null;
		}
	}
}
