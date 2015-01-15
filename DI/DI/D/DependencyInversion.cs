using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
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
