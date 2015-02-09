using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatterns
{
	public class Copier
	{
		public static void Copy()
		{
			int c;
			while ((c = Keyboard.Read()) != -1)
				Print.Write(c);
		}
	}

	public static class Print
	{
		public static void Write(int c)
		{
			// типа печатаем
		}
	}
	public static class Keyboard
	{
		public static int Read()
		{
			int c = 0;
			return c;
		}
	}
}
