using System;
using Xunit;
using BinaryTree;

namespace TestTree
{
    public class Tests
    {
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
        [Fact]
        public void Test1()
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

            int n = 9;
            
            Assert.Equal(students.Count, n);
        }
    }
}