using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace BinTree
{
	class Program
	{
		static void Main(string[] args)
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

			students.PreOrderTraversal(Console.WriteLine);
			Console.WriteLine("\n");
			Console.WriteLine($"There are {students.Count} students");
			Console.WriteLine("\n");
			Console.WriteLine($"Is student {new Student("Ivan", "Sobko", 9).ToString()} here?" +
				$"  {students.Contains(new Student("Ivan", "Sobko", 9))}");
			Console.WriteLine("\n");
			Console.WriteLine($"Is student {new Student("Ivan", "Sobko", 99).ToString()} here?" +
				$"  {students.Contains(new Student("Ivan", "Sobko", 99))}");
			Console.WriteLine("\n");
			Console.WriteLine($"Student {new Student("Ivan", "Sobko", 9).ToString()} has been removed   " + 
				$"{students.Remove(new Student("Ivan", "Sobko", 9))}");
			Console.WriteLine("\n");
			Console.WriteLine($"There are {students.Count} students now");

			foreach (var item in students)
			{ 
				Console.WriteLine(item );
			}
			Console.WriteLine("\n\n-----\n\n");
			foreach (var item in students.InOrder)
			{
				Console.WriteLine(item);
			}
			
			Console.WriteLine("\n\n________________________\n\n");

			IndexArray<int> arr = new IndexArray<int>(3);
			arr.Add(1);
			arr.Add(2);
			arr.Add(4);
			arr.Add(5);
			arr.Add(6);
			Console.WriteLine("Array from 3th position: ");
			foreach (var item in arr)
			{
				Console.Write(item + "  ");
			}
			Console.WriteLine($"There are {arr.Count} items");
			Console.WriteLine($"This is array[6] element: {arr[6]}");
			Console.WriteLine($"Array contains 7? {arr.Contains(7)}\n Array contains 5?  {arr.Contains(5)}");
			arr.Remove(5);
			Console.WriteLine("5 has been removed:");
			foreach (var item in arr)
			{
				Console.Write(item + "  ");
			}
			Console.WriteLine($"There are {arr.Count} items");
			Console.WriteLine("3rd element has been removed:");
			arr.RemoveAt(3);
			foreach (var item in arr)
			{
				Console.Write(item + "  ");
			}
			Console.WriteLine($"There are {arr.Count} items");

			Console.ReadKey();

		}
		class Student : IComparable
		{
			public string Name;
			public string Surname;
			public int Score;
			public Student(string Name, string Surname,int Score)
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
	}
}
