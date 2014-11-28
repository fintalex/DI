using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
	class Program
	{
		static void Main(string[] args)
		{
			// создаем  новый экземпляр класса ConsoleMessageWriter, который мы знаем реализует функциональность вывода на экран
			// экземпляр мы передает классу Salutation, который теперь знает куда выводить сообщение 
			IMessageWriter writer = new ConsoleMessageWriter();

			//var typeName = .AppSerrings["messageWriter"];
			Salutation salutation = new Salutation(writer);
			salutation.Exclaim(" hello DI");

			Console.ReadLine();
		}
	}

	// класс Salutation зависит от интерфейса IMessageWriter , 
	// и поэтому запрашивает экземпляр реализующий этот интерфейс в свой конструктор
	public class Salutation 
	{
		private readonly IMessageWriter writer;
		// внедрение зависимости через конструктор (Constructor Injection)
		public Salutation(IMessageWriter writer)
		{
			this.writer = writer;
		}

		public void Exclaim(string mess)
		{
			// использование зависимости - нашего переданного экземпляра класса
			writer.Write(mess);
		}
	}

	public interface IMessageWriter
	{
		void Write(string message);
	}

	// реализует интерфейс IMessageWriter путем создания обертки метод Write для класса Console
	// такая реализация называется патерном "Адаптер"
	public class ConsoleMessageWriter : IMessageWriter
	{
		public void Write(string mess)
		{
			Console.WriteLine("Here our message:" + mess);
		}
	}

}
