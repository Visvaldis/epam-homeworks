using System;
using Xunit;
using BinaryTree;
using System.Collections.Generic;

namespace Tests_BinaryTree
{
	public class Test_BinarySearchTree
	{
		class Student : IComparable
		{
			public string Name;
			public string Surname;
			public int Score;
			public Student(string Name, string Surname, int Score)
			{
				this.Name = Name;
				this.Surname = Surname;
				this.Score = Score;
			}

			public int CompareTo(object obj)
			{
				Student other = (Student)obj;
				return Score.CompareTo(other.Score);
			}

			public override string ToString()
			{
				return $"{Name} {Surname} has {Score} balls";
			}
		}

		[Theory]
		[InlineData(0)]
		[InlineData(5)]
		[InlineData(15)]
		[InlineData(1000)]
		[InlineData(8)]
		public void TestAdd_ShouldReturn_Param(int param)
		{

			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			Random r = new Random();
			for (int i = 0; i < param; i++)
			{
				tree.Add(r.Next(0, 500));
			}

			int actual = param;
			int current = tree.Count;

			Assert.Equal(current, actual);
			Assert.True(tree.isCorrect());
		}


		[Fact]
		public void TestAdd_WithClass_ShouldReturn_9()
		{
			BinarySearchTree<Student> students = new BinarySearchTree<Student>();
			students.Add(new Student("Ivan", "Ivanov", 18));
			students.Add(new Student("Petr", "Petrov", 20));
			students.Add(new Student("Pavel", "Pavlov", 5));
			students.Add(new Student("Ruslan", "Kudelin", 2));
			students.Add(new Student("Dmytro", "Ignatov", 15));
			students.Add(new Student("Alex", "Kozin", 8));
			students.Add(new Student("Ivan", "Sobko", 9));
			students.Add(new Student("Boris", "Borisov", 4));
			students.Add(new Student("Sveta", "Mul", 19));

			int actual = 9;

			int current = students.Count;

			Assert.Equal(current, actual);
			Assert.True(students.isCorrect());
		}

		[Theory]
		[InlineData(0)]
		[InlineData(50)]
		[InlineData(15)]
		[InlineData(100000)]
		[InlineData(8)]
		public void TestClear_ShouldReturn_0(int param)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			Random r = new Random();
			for (int i = 0; i < param; i++)
			{
				tree.Add(r.Next(0, 1000));
			}

			tree.Clear();
			int actual = 0;
			int current = tree.Count;

			Assert.Equal(current, actual);
			Assert.True(tree.isCorrect());
		}


		[Fact]
		public void TestContains_ShouldReturn_True()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);
			tree.Add(18);

			// act
			bool current = tree.Contains(19);

			// assert
			Assert.True(current);
			Assert.True(tree.isCorrect());
		}


		[Fact]
		public void TestContains_ShouldReturn_False()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);
			tree.Add(18);

			// act
			bool current = tree.Contains(22);
			// assert
			Assert.False(current);
			Assert.True(tree.isCorrect());
		}




		[Fact]
		public void TestRemove_ShouldReturn_True()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);
			tree.Add(18);

			// act
			bool current = tree.Remove(15);
			// assert
			Assert.True(current);
			Assert.True(tree.isCorrect());
		}


		[Fact]
		public void TestRemove_ShouldReturn_False()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);
			tree.Add(18);

			// act
			bool current = tree.Remove(9);
			// assert
			Assert.True(tree.isCorrect());
			Assert.False(current);
		}


		[Fact]
		public void TestToList_Preorder()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);


			List<int> actual = new List<int>(new[] { 20, 15, 10, 8, 13, 11, 17, 19, 25, 24, 38, 26 });


			// act
			List<int> current = tree.ToList(BinarySearchTree<int>.Traversals.PreOrderTraversal);

			// assert
			Assert.Equal(current, actual);
		}

		[Fact]
		public void TestToList_InOrder()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);

			List<int> actual = new List<int>(new[] { 8, 10, 11, 13, 15, 17, 19, 20, 24, 25, 26, 38 });


			// act
			List<int> current = tree.ToList(BinarySearchTree<int>.Traversals.InOrderTraversal);

			// assert
			Assert.Equal(current, actual);
		}
		[Fact]
		public void TestToList_PostOrder()
		{
			// arrange
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(20); tree.Add(15);
			tree.Add(10); tree.Add(17);
			tree.Add(19); tree.Add(8);
			tree.Add(25); tree.Add(38);
			tree.Add(24); tree.Add(26);
			tree.Add(13); tree.Add(11);


			List<int> actual = new List<int>(new[] { 8, 11, 13, 10, 19, 17, 15, 24, 26, 38, 25, 20 });


			// act
			List<int> current = tree.ToList(BinarySearchTree<int>.Traversals.PostOrderTraversal);

			// assert
			Assert.Equal(current, actual);
		}
		
	}
}
