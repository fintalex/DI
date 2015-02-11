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
		private static bool[] isCrossed;
		private static int[] result;

		public static int[] GeneratePrimeNumbers(int maxValue)
		{
			if (maxValue < 2)
				return new int[0];
			else
			{
				InitializeArrayOfIntegers(maxValue);
				CrossOutMultiples();
				PutUncrossedIntegersIntoResult();
				return result; // вернуть простые числа
			}
		}
		private static void InitializeArrayOfIntegers(int maxValue)
		{
			isCrossed = new bool[maxValue + 1];
			for (int i = 2; i < isCrossed.Length; i++)
			{
				isCrossed[i] = false;
			}
		}
		private static void CrossOutMultiples()
		{
			int maxPrimefactor = CalcMaxPrimeFactor();
			for (int i = 2; i < maxPrimefactor; i++)
			{
				if (NotCrossed(i))
					CrossOutputMultiplesOf(i);
			}
		}
		private static int CalcMaxPrimeFactor()
		{
			// Вычеркиваем все кратные p, где p – простое число. Таким
			// образом, любое вычеркнутое число разлагается в произведение
			// множителей p и q. Если p > sqrt из размера массива, то q не
			// может быть больше 1. Таким образом, p – максимальный простой
			// множитель всех чисел в массиве и одновременно верхний предел
			// итераций.
			double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
			return (int)maxPrimeFactor;
		}

		private static void CrossOutputMultiplesOf(int i)
		{
			for (int multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
				isCrossed[multiple] = true;
		}
		private static bool NotCrossed(int i)
		{
			return isCrossed[i] == false;
		}
		private static void PutUncrossedIntegersIntoResult()
		{
			result = new int[NumberOfUncrossedIntegers()];
			for (int i = 2, j =0 ; i < isCrossed.Length; i++)
			{
				if (NotCrossed(i))
					result[j++] = i;
			}
		}
		private static int NumberOfUncrossedIntegers()
		{
			int count = 0;
			for (int i = 2; i < isCrossed.Length; i++)
			{
				if (NotCrossed(i))
					count++; 
			}
			return count;
		}
	}
}
