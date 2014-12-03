class Program
	{
		static void Main(string[] args)
		{
			// registration
			var container = new WindsorContainer();
			container.Register(Component.For<ILogger>().ImplementedBy<Logger>());
			// resolving 
			var logger = container.Resolve<ILogger>();
			logger.Log("Hello World");
			Console.ReadLine();
		}

		interface ILogger
		{
			void Log(string message);
		}
		class Logger : ILogger
		{
			public void Log(string message)
			{
				Console.WriteLine(message);
			}
		}
	}
