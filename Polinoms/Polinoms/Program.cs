using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Polinoms
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] exp = new int[] {11, 2, 5, 7, 3 };
			int[] coef = new int[] { -11, 2, 4, 0, 4 };

			int[] exp1 = new int[] { 1, 2, 5, 7, 8 };
			int[] coef1 = new int[] { -1, -2, 4, 8, 4 };
			try
			{
			/*	Polinom p = new Polinom(exp, coef);
				Console.WriteLine(p);

				Polinom p1 = new Polinom(exp1, coef1);
				Console.WriteLine(p1);
				Console.WriteLine(p+p1);
				Console.WriteLine(p - p1);

				Polinom p2 = new Polinom(new int[] { 1, 0 }, new int[] { 2, 5 });
				Console.WriteLine(p2);
				Console.WriteLine(p2*p2);*/
				Polinom c = null;
				Polinom a = new Polinom(c);
				a.GetCoefficient(5);

			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
				Console.WriteLine("hi");
			}

			/*
			SortedDictionary<int, int> d = new SortedDictionary<int, int>();
			d.Add(1, 1);
			d.Add(4, 6);
			d.Add(8, 2);
			d.Add(6, 1);
			Console.WriteLine(d);
			foreach (var itm in d)
			{
				Console.WriteLine($"{itm.Key}  {itm.Value}");
			}
			d.Add(6, 7);
			foreach (var itm in d)
			{
				Console.WriteLine($"{itm.Key}  {itm.Value}");
			}

	*/
			ReadKey();
		}
	}
}
