using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringByMartin2
{
	///<remark>
	/// Этот класс генерирует простые числа, не превышающие заданного
	/// пользователем порога. В качестве алгоритма используется решето
	/// Эратосфена.
	/// Пусть дан массив целых чисел, начинающийся с 2:
	/// Находим первое невычеркнутое число и вычеркиваем все его
	/// кратные. Повторяем, пока в массиве не останется кратных.
	///</remark>
	public class PrimeGenerator
	{
		private static bool[] f;
		private static int[] result;

		public static int[] GeneratePrimeNumbers(int maxValue)
		{
			if (maxValue < 2)
				return new int[0];
			else
			{
				InitializeSieve(maxValue);
				Sieve();
				LoadPrimes();
				return result; // вернуть простые числа
			}
		}
		private static void LoadPrimes()
		{
			int i;
			int j;
			// сколько оказалось простых чисел?
			int count = 0;
			for (i = 0; i < f.Length; i++)
			{
				if (f[i])
					count++; // увеличить счетчик
			}
			result = new int[count];
			// поместить простые числа в результирующий массив
			for (i = 0, j = 0; i < f.Length; i++)
			{
				if (f[i]) // если простое
					result[j++] = i;
			}
		}
		private static void Sieve()
		{
			int i;
			int j;
			for (i = 2; i < Math.Sqrt(f.Length) + 1; i++)
			{
				if (f[i]) // если i не вычеркнуто, вычеркнуть его кратные.
				{
					for (j = 2 * i; j < f.Length; j += i)
						f[j] = false; // кратное – не простое число
				}
			}
		}
		private static void InitializeSieve(int maxValue)
		{
			// объявления
			f = new bool[maxValue + 1];
			int i;
			// инициализировать элементы массива значением true.
			for (i = 0; i < f.Length; i++)
				f[i] = true;
			// исключить заведомо не простые числа
			f[0] = f[1] = false;
		}

	}
}
