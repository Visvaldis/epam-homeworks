using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

	public class BinarySearchTree<T> : IEnumerable<T>, ICollection<T> where T : IComparable
	{
		Node<T> root;
		public enum Traversals
		{
			PreOrderTraversal,
			InOrderTraversal,
			PostOrderTraversal
		}

		public BinarySearchTree()
		{
			root = null;
			nodesCount = 0;
		}

		int nodesCount;
		public int Count => nodesCount;

		public bool IsReadOnly => true;

		public IEnumerable<T> InOrder => this.ToList(Traversals.InOrderTraversal);
		public IEnumerable<T> PreOrder => this.ToList(Traversals.PreOrderTraversal);
		public IEnumerable<T> PostOrder => this.ToList(Traversals.PostOrderTraversal);

		public void Add(T item)
		{
			if (item == null) throw new ArgumentNullException();
			if (root == null)
			{
				root = new Node<T>(item);
			}
			else AddItem(root, item);
			nodesCount++;
		}
		private void AddItem(Node<T> root, T item)
		{
			if (root.GetValue().CompareTo(item) > 0)
				if (root.Left == null)
					root.Left = new Node<T>(item);
				else
					AddItem(root.Left, item);
			else
			{
				if (root.Right == null)
					root.Right = new Node<T>(item);
				else
					AddItem(root.Right, item);
			}
		}

		public void Clear()
			=> Clear(root);
		private void Clear(Node<T> root)
		{
			if (root == null) return;
			if (root.Left != null)
				Clear(root.Left);
			if (root.Right != null)
				Clear(root.Right);
			root = null;
			nodesCount--;
		}

		public bool Contains(T item)
			=> Contains(root, item);
		private bool Contains(Node<T> root, T item)
		{
			if (item == null) throw new ArgumentNullException();
			if (root == null) return false;

			if (root.GetValue().CompareTo(item) == 0)
				return true;
			else if (root.GetValue().CompareTo(item) > 0)
				return Contains(root.Left, item);
			else
				return Contains(root.Right, item);
		}


		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("The array cannot be null.");
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
			if (Count > array.Length - arrayIndex + 1)
				throw new ArgumentException("The destination array has fewer elements than the collection.");

			List<T> temp = new List<T>();
			PreOrderTraversal(temp.Add);
			for (int i = 0; i < temp.Count; i++)
			{
				array[i + arrayIndex] = temp[i];
			}
		}


		public bool Remove(T item)
			=> Remove(ref root, item);
		private bool Remove(ref Node<T> root, T item)
		{
			if (item == null) throw new ArgumentNullException();
			if (root == null) return false;

			if (root.GetValue().CompareTo(item) == 0)
			{
				if (root.Left == null && root.Right == null)
				{
					root = null;
				}
				else if (root.Left != null && root.Right == null)
				{
					root = root.Left;
				}
				else if (root.Left == null && root.Right != null)
				{
					root = root.Right;
				}
				else if (root.Right.Left == null)
				{
					root = root.Right;
				}
				else
				{
					Node<T> leftmost = root.Right;
					Node<T> leftmost_parent = root;
					while (leftmost.Left != null)
					{
						leftmost_parent = leftmost;
						leftmost = leftmost.Left;
					}
					leftmost_parent.Left = leftmost.Right;
					leftmost.Left = root.Left;
					leftmost.Right = root.Right;
					root = leftmost;
				}

				nodesCount--;
				return true;
			}
			else if (root.GetValue().CompareTo(item) > 0)
				return Remove(ref root.Left, item);
			else
				return Remove(ref root.Right, item);
		}


		public List<T> ToList(Traversals traver)
		{
			List<T> result = new List<T>();
			switch (traver)
			{
				case Traversals.PreOrderTraversal:
					PreOrderTraversal(result.Add);
					break;
				case Traversals.InOrderTraversal:
					InOrderTraversal(result.Add);
					break;
				case Traversals.PostOrderTraversal:
					InOrderTraversal(result.Add);
					break;
			}

			return result;
		}


		public IEnumerator<T> GetEnumerator()
		{
			return this.ToList(Traversals.PreOrderTraversal).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		public void PreOrderTraversal(Action<T> action)
		{
			if (action == null) throw new ArgumentNullException();
			PreOrderTraversal(action, root);
		}
		private void PreOrderTraversal(Action<T> action, Node<T> node)
		{
			
			if (node != null)
			{
				action(node.GetValue());
				PreOrderTraversal(action, node.Left);
				PreOrderTraversal(action, node.Right);
			}
		}


		public void InOrderTraversal(Action<T> action)
		{
			if (action == null) throw new ArgumentNullException();
			InOrderTraversal(action, root);
		}
		private void InOrderTraversal(Action<T> action, Node<T> node)
		{
			if (node != null)
			{
				InOrderTraversal(action, node.Left);
				action(node.GetValue());
				InOrderTraversal(action, node.Right);
			}
		}


		public void PostOrderTraversal(Action<T> action)
		{
			if (action == null) throw new ArgumentNullException();
			PostOrderTraversal(action, root);
		}
		private void PostOrderTraversal(Action<T> action, Node<T> node)
		{
			if (node != null)
			{
				PostOrderTraversal(action, node.Left);
				PostOrderTraversal(action, node.Right);

			}
		}
	}
	public class Node<T> 
	{
		T value;
		public Node<T> Left;
		public Node<T> Right;

		public Node()
		{
			value = default(T);
			Left = null;
			Right = null;
		}
		public Node(T value)
		{
			this.value = value;
		}
		public Node(Node<T> another)
		{
			value = another.GetValue();
			Left = another.Left;
			Right = another.Right;
		}
		public T GetValue()
		{
			return value;
		}
	}
}
