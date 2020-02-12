﻿using System;
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



				Console.ReadKey();
				Console.WriteLine();
			}
			{
				//LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
				//Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
				//Отсортировать полученную последовательность по возрастанию.
				//TODO
				Console.WriteLine("LinqBegin44");

				
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


				Console.ReadKey();
				Console.WriteLine();
			}
		}
	}
}
