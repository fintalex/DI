using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringByMartin3
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
		private static bool[] crossedOut;
		private static int[] result;

		public static int[] GeneratePrimeNumbers(int maxValue)
		{
			if (maxValue < 2)
				return new int[0];
			else
			{
				UncrossIntegersUpTo(maxValue);
				CrossOutMultiples();
				PutUncrossedIntegersIntoResult();
				return result; // вернуть простые числа
			}
		}
		private static void UncrossIntegersUpTo(int maxValue)
		{
			crossedOut = new bool[maxValue + 1];
			for (int i = 2; i < crossedOut.Length; i++)
			{
				crossedOut[i] = false;
			}
		}
		private static void CrossOutMultiples()
		{
			int limit = DetermineIterationLimit();
			for (int i = 2; i < limit; i++)
			{
				if (NotCrossed(i))
					CrossOutputMultiplesOf(i);
			}
		}
		private static int DetermineIterationLimit()
		{
			// У каждого составного числа в этом массиве есть простой
			// множитель, меньший или равный квадратному корню из размера
			// массива, поэтому необязательно вычеркивать кратные, большие
			// корня.
			double maxPrimeFactor = Math.Sqrt(crossedOut.Length) + 1;
			return (int)maxPrimeFactor;
		}

		private static void CrossOutputMultiplesOf(int i)
		{
			for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
				crossedOut[multiple] = true;
		}
		private static bool NotCrossed(int i)
		{
			return crossedOut[i] == false;
		}
		private static void PutUncrossedIntegersIntoResult()
		{
			result = new int[NumberOfUncrossedIntegers()];
			for (int i = 2, j =0 ; i < crossedOut.Length; i++)
			{
				if (NotCrossed(i))
					result[j++] = i;
			}
		}
		private static int NumberOfUncrossedIntegers()
		{
			int count = 0;
			for (int i = 2; i < crossedOut.Length; i++)
			{
				if (NotCrossed(i))
					count++; 
			}
			return count;
		}
	}
}
