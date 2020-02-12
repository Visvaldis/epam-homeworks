using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//?? Как сделать неизменяемый извне словарь
//?? Как сделать обработку изменений данных словаря
namespace Polinoms
{
	class Polinom
	{
		 SortedDictionary<int, int> Data
		{
			get; set;
		}
		public int Power { get {return Data.Keys.Last(); } }

		public Polinom()
		{	
			Data = new SortedDictionary<int, int>();
		}
		public Polinom(Dictionary<int, int> Values)
		{
			if (Values is null) throw new ArgumentNullException();
			ChangeData(Values);
		}
		public Polinom(int[] Exponents, int[] Coefficients)
		{
			ChangeData(Exponents, Coefficients);
		}

		public Polinom( Polinom p)
		{
			if (p is null) throw new ArgumentNullException();
			Data = new SortedDictionary<int, int>(p.Data);
		}


		public override string ToString()
		{
			string st = string.Empty;

			foreach (var item in Data.Reverse())
			{
				if (item.Value >   0)
				{
					if (item.Key == 0) st += $"+ {item.Value}";
					else
						st += $"+ {item.Value}x^{item.Key} ";
				}
				else if (item.Value < 0)
				{
					if (item.Key == 0) st += $"- {Math.Abs(item.Value)}";
					else
						st += $"- {Math.Abs(item.Value)}x^{item.Key} ";
				}
			}
			return st.TrimStart(new char[] {'+', ' '});
		}
		public void ChangeCoeffcient(int Exponent, int NewCoeffcient)
		{
			if (Data.Keys.Contains(Exponent))
				Data[Exponent] = NewCoeffcient;
			else
				Data.Add(Exponent, NewCoeffcient);
		}
		public int GetCoefficient(int Exponent)
		{
			if (Data.Keys.Contains(Exponent))
				return Data[Exponent];
			else
				return 0;
		}
		public SortedDictionary<int, int> GetData()
		{
			return Data;
		}

		public void ChangeData(int[] Exponents, int[] Coefficients)
		{
			if (Exponents is null || Coefficients is null) throw new ArgumentNullException();
			if (Exponents.Length != Coefficients.Length)
				throw new ArgumentException("Arrrays have different length");
			Data = new SortedDictionary<int, int>();
			for (int i = 0; i < Exponents.Length; i++)
			{
				if (Data.ContainsKey(Exponents[i]))
				{
					Data = new SortedDictionary<int, int>();
					throw new ArgumentException($"Wrong exponents array: some values are repeat ({Exponents[i]})");
				}
				Data.Add(Exponents[i], Coefficients[i]);
			}
		}

		public void ChangeData(Dictionary<int, int> Values)
		{
			if (Values is null) throw new ArgumentNullException();
			Data = new SortedDictionary<int, int>(Values);
		}

		public static Polinom operator +(Polinom a, Polinom b)
		{
			if (a is null || b is null) throw new ArgumentNullException();

			Polinom c = new Polinom(a);

			foreach (var item in b.Data)
			{
				if (c.Data.Keys.Contains(item.Key))
					c.Data[item.Key] += item.Value;
				else
					c.Data.Add(item.Key, item.Value);
			}
			return c;
		}
		public static Polinom operator -(Polinom a, Polinom b)
		{
			if (a is null || b is null) throw new ArgumentNullException();

			Polinom c = new Polinom(a);
			foreach (var item in b.Data)
			{
				if (c.Data.Keys.Contains(item.Key))
					c.Data[item.Key] -= item.Value;
				else
					c.Data.Add(item.Key, -item.Value);
			}
			return c;
		}

		public static Polinom operator *(Polinom a, Polinom b)
		{
			if (a is null || b is null) throw new ArgumentNullException();

			Polinom c = new Polinom();
			int key = 0, val = 0;
			foreach (var itemA in a.Data)
			{
				foreach (var itemB in b.Data)
				{
					key = itemA.Key + itemB.Key;
					val = itemA.Value * itemB.Value;
					if (c.Data.Keys.Contains(key))
					{
						c.Data[key] += val;
					}
					else
						c.Data.Add(key, val);
				}
			}
			return c;
		}
	}
}
