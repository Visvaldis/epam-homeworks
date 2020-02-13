using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTest
{
	class Program
	{
		static void Main(string[] args)
		{
			{
				//LinqBegin6. Дана строковая последовательность.
				//Найти сумму длин всех строк, входящих в данную последовательность.
				//TODO
				Console.WriteLine("LinqBegin6");

				List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
				int count = str.Sum(x => x.Length);

				Console.WriteLine(count);
				Console.ReadKey();
				Console.WriteLine();
			}
			{

				//LinqBegin11. Дана последовательность непустых строк. 
				//Пполучить строку, состоящую из начальных символов всех строк исходной последовательности.
				//TODO
				Console.WriteLine("LinqBegin11");

				List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
				var first = str.Select(x => x.First());
				string sFirst = default(string);
				foreach (var item in first)
				{
					sFirst += item;
				}
				Console.WriteLine(sFirst);
				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqBegin22. Дано целое число K (> 0) и строковая последовательность A.
				//Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
				//Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их по возрастанию.
				//TODO
				Console.WriteLine("LinqBegin22");

				List<string> str = new List<string> { "q qwerty1", "cqwertyc", "cqwe2", "c", "fgrftgd4" };
				int k = 8;

				var strs = str.Where(x => x.Length == k && Char.IsNumber(x.Last())).OrderBy(x => x);
				foreach (var item in strs)
				{
					Console.WriteLine(item);
				}
					
				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqBegin29. Даны целые числа D и K (K > 0) и целочисленная последовательность A.
				//Найти теоретико - множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
				//большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K.
				//Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.
				//TODO
				Console.WriteLine("LinqBegin29");

				int d = 6, k = 8;
				int[] a = { 1, 3, 5, 6, 3, 6, 7, 8, 45, 3, 7, 6 };
				
				var n = a.TakeWhile(i => i < d).Concat(a.Skip(k)).Distinct().OrderBy(x => x);
				foreach (int item in n)
				{
					Console.Write(item + "  ");
				}
				
				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqBegin36. Дана последовательность непустых строк. 
				//Получить последовательность символов, которая определяется следующим образом: 
				//если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве
				//символа берется первый символ этой строки; в противном случае берется последний символ строки.
				//Отсортировать полученные символы по убыванию их кодов.
				//TODO
				Console.WriteLine("LinqBegin36");

				List<string> str = new List<string> { "q werty1", "aqwertyc", "dcqwe2", "c", "fgrftgd4" };
				var chars = str.Select(x => x.Length % 2 == 1 ? x.First() : x.Last()).OrderByDescending(x => x);
				foreach (char item in chars)
				{
					Console.Write(item + "  ");
				}
				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
				//Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
				//Отсортировать полученную последовательность по возрастанию.
				//TODO
				Console.WriteLine("LinqBegin44");

				int[] a = { 1, 3, 5, 6, 3, 6, 7, 8, 45, 3, 7, 6 };
				int[] b = { 10, 13, 4, 7, 27, 8, 11, 12, 2, 4, 6, 9 };
				int k1 = 7, k2 = 10;
				var n = a.Where(x => x > k1).Concat(b.Where(x => x < k2)).OrderBy(x=> x);
				foreach (int item in n)
				{
					Console.Write(item + "  ");
				}
				Console.ReadKey();
				Console.WriteLine();
			}

			{
				//LinqBegin48.Даны строковые последовательности A и B; все строки в каждой последовательности различны, 
				//имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита. 
				//Найти внутреннее объединение A и B, каждая пара которого должна содержать строки одинаковой длины.
				//Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
				//разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться порядком 
				//первых элементов пар(по возрастанию), а для равных первых элементов — порядком вторых элементов пар(по убыванию).
				//TODO
				Console.WriteLine("LinqBegin48");

				List<string> aList = new List<string> {"erty1", "aqwertyc", "dcqwew2", "c", "fgrweftgd4"};
				List<string> bList = new List<string> {"qwerty1", "aqwer", "dcqwe2", "c", "fgrfetgd4"};

				var str = aList.Join(bList, x => x.Length, y => y.Length, (x, y) => $"{x} : {y}")
					.OrderBy(x => x.Substring(0, x.IndexOf(' ')))
					.ThenByDescending(x => x.Substring(x.LastIndexOf(' '), x.Length - x.LastIndexOf(' ')));

				foreach (var item in str)
				{
					Console.WriteLine(item);
				}

				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqObj17. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности
				//включает следующие поля: < Номер школы > < Год поступления > < Фамилия >
				//Для каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
				//поступившие в этом году (вначале указывать число школ, затем год). 
				//Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию числа школ, 
				//а для совпадающих чисел — по возрастанию номера года.
				//TODO
				Console.WriteLine("LinqObj17");
				
				var abits = new List<Abit>
				{
					new Abit{Surname = "Ivanov",   Year =   2015, SchoolNumber = 18},
					new Abit{Surname = "Petrov",   Year =   2014, SchoolNumber = 20},
					new Abit{Surname = "Pavlov",   Year =   2015, SchoolNumber = 18 },
					new Abit{Surname =  "Kudelin", Year =   2017, SchoolNumber = 2 },
					new Abit{Surname =  "Ignatov", Year =   2016, SchoolNumber = 15},
					new Abit{Surname = "Kozin",    Year =   2016, SchoolNumber = 8 },
					new Abit{Surname = "Sobko",    Year =   2018, SchoolNumber = 15 },
					new Abit{Surname = "Borisov",  Year =   2015, SchoolNumber = 4 },
					new Abit{Surname = "Mul",      Year =   2017, SchoolNumber = 20}
				};

				var strs = abits.GroupBy(x => x.Year)
					.Select(x => new {Count = x.Distinct().Count(), Year = x.Key})
					.OrderBy(x => x.Year);
				
				foreach (var item in strs)
				{
					Console.WriteLine($"{item.Count} : {item.Year}");
				}
				Console.ReadKey();
				Console.WriteLine();
			}
		}
	}

	class Abit
	{
		public string Surname;
		public int SchoolNumber;
		public int Year;
	}
}
