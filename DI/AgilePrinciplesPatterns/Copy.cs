using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// пример плохой программы
namespace AgilePrinciplesPatterns
{
	 // программу, которая выводит непосредственно на принтер текст, вводимый с клавиатуры
	//public class Copier
	//{
	//	public static void Copy()
	//	{
	//		int c;
	//		while ((c = Keyboard.Read()) != -1)
	//			Print.Write(c);
	//	}
	//}
	//======= если надо добавить условие, что программа должна читать с перфоленты=====
	//public class Copier
	//{
	//	// не забудьте сбросить этот флаг
	//	public static bool ptFlag = false;
	//	public static void Copy()
	//	{	
	//		int c;
	//		while ((c = (ptFlag? PaperTape.Read() :  Keyboard.Read())) != -1)
	//			Print.Write(c);
	//	}
	//}
	//========= но если надо использовать Copy для выводана перфоленту ===================
	public class Copier
	{
		// не забудьте сбросить этот флаги
		public static bool ptFlag = false;
		public static bool punchFlag = false;

		public static void Copy()
		{
			int c;
			while ((c = (ptFlag ? PaperTape.Read() : Keyboard.Read())) != -1)
			{
				if (punchFlag)
					PaperTape.Punch(c);
				else
					Print.Write(c);
			}
		}
	}


	// ============= это условный вспомогательный код
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
	public static class PaperTape
	{
		public static int Read()
		{
			int c = 0;
			return c;
		}
		public static void Punch(int c)
		{
			// типа печатаем
		}
	}
}

// а теперь гибкий вариант
namespace AgilePrinciplesPatterns2
{
	//============================== начнем с первого этапа =============================
	// программу, которая выводит непосредственно на принтер текст, вводимый с клавиатуры
	public interface Reader
	{
		int Read();
	}
	public class KeyboaredReader : Reader
	{
		public int Read()
		{
			return Keyboard.Read();
		}
	}
	public class Copier
	{
		public static Reader reader = new KeyboaredReader();
		public static void Copy()
		{
			int c;
			while ((c = (reader.Read())) != -1)
				Print.Write(c);
		}
	}
	// в данном случае мы применили принцип открытости\закрытости 
	// проектирование модулей так чтобы их можно было расширять без модификаций


	// ============= это условный вспомогательный код

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
	public static class PaperTape
	{
		public static int Read()
		{
			int c = 0;
			return c;
		}
		public static void Punch(int c)
		{
			// типа печатаем
		}
	}
}