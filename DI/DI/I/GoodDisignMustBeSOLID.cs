using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// другой пример из http://igor.quatrocode.com/2008/09/solid-top-5.html
// зависимость между классами должна быть ограничена как можно более узким интерфейсом
namespace GoodDisignMustBeSOLID
{
	abstract class ServiceClient
	{
		public string ServiceUri { set; get; }
		public abstract void SendData(object data);
		public abstract void Flush();
	}

	class HttpServiceClient : ServiceClient
	{
		public override void SendData(object data)
		{
			//var channel = OpenChannel(ServiceUri);
			//channel.Send(data);
		}

		public override void Flush()
		{
			// Метод ничего не делает, но присутствует в классе
		}
	}

	class BufferingHttpServiceClient : ServiceClient
	{
		public override void SendData(object data)
		{
			//Buffer.Writte(data);
		}

		public override void Flush()
		{
			//var channel = OpenChannel(ServiceUri);
			//channel.Send(Buffer.GetAll())
		}
	}
}

// решение должно быть в проектировании грамотной иерархии интерфейсов

namespace GoodDisignMustBeSOLID2
{
	abstract class ServiceClient
	{
		public string ServiceUri { set; get; }
		// оставили здесь эту сигнатуру метода, так как она используется в обоих классах
		public abstract void SendData(object data);
	}
	// создаем наследника нашего интерфейса и задаем в нем второй метода который используется не во всех классах
	// а подчиненном абстрактном классе не обязательно переопределять родительский абстрактный метод
	abstract class BufferingServiceClient : ServiceClient
	{
		public abstract void Flush();
	}

	// получается сейчас мы можем создавать классы наследники в которых нужно будет переопределить 
	// BufferingServiceClient: Flush и SendData
	// ServiceClient: только SendData

	class HttpServiceClient : ServiceClient
	{
		// нам второй метод Flush не нужен был и мы от него избавились
		public override void SendData(object data)
		{
			throw new NotImplementedException();
		}
	}

	class BufferingHttpServiceClient : BufferingServiceClient
	{
		// а вот другой подчиненный абстрактный класс имеет более расширенный набор методов который мы должны реализовать
		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override void SendData(object data)
		{
			throw new NotImplementedException();
		}
	}
}