using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using RefactoringByMartin;
using RefactoringByMartin2;

[TestFixture]
class GeneratePrimesTest
{
	//В первом случае простых чисел
	//вообще не должно быть. Во втором случае должно быть одно простое
	//число – 2. В третьем случае должно быть два простых числа – 2 и 3.
	//А в четвертом – 25 простых чисел, последнее из которых равно 97
	[Test]
	public void TestPrimes()
	{
		int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
		Assert.AreEqual(nullArray.Length, 0);

		int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
		Assert.AreEqual(minArray.Length, 1);
		Assert.AreEqual(minArray[0], 2);

		int[] threeArray = PrimeGenerator.GeneratePrimeNumbers(3);
		Assert.AreEqual(threeArray.Length, 2);
		Assert.AreEqual(threeArray[0], 2);
		Assert.AreEqual(threeArray[1], 3);

		int[] centArray = PrimeGenerator.GeneratePrimeNumbers(100);
		Assert.AreEqual(centArray.Length, 25);
		Assert.AreEqual(centArray[24], 97);
	}
}

