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

