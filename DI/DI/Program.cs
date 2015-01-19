using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DependencyInversion;
//using TheInterfaceSegregationPrinciple3;
//using GoodDisignMustBeSOLID2;
//using StrongCoupling;
//using StrongCoupling2;
//using RectangleExample;

namespace SOLID
{
	class Program
	{
		static void Main(string[] args)
		{
            //// ===========================================  DependencyInversion   =============================================================
            //// создаем  новый экземпляр класса ConsoleMessageWriter, который мы знаем реализует функциональность вывода на экран
            //// экземпляр мы передает классу Salutation, который теперь знает куда выводить сообщение 
            //IMessageWriter writer = new ConsoleMessageWriter();

            ////var typeName = .AppSerrings["messageWriter"];
            //Salutation salutation = new Salutation(writer);
            //salutation.Exclaim(" hello DI");

            //Console.ReadLine();

			//// ===========================================  TheInterfaceSegregationPrinciple 2-3   =============================================================
			//ProductAuditor pa = new ProductAuditor();
			//pa.AuditEntityFieldSet();

			//AccountAuditor aa = new AccountAuditor();
			//aa.AuditEntityFieldSet();

			////// ===========================================  GoodDisignMustBeSOLID2 2  =============================================================
			//HttpServiceClient httpsc = new HttpServiceClient();
			//BufferingHttpServiceClient buffersc = new BufferingHttpServiceClient();
			//// видим только один мтеод
			//httpsc.SendData(new object()); 
			//// видим оба метода
			//buffersc.SendData(new object());
			//buffersc.Flush(); 
            
            //// ===========================================  StrongCoupling  =============================================================
            //var builder = new ReportBuilder();
            //var sender = new EmailReportSender();
            //var reporter = new Reporter(builder, sender);
            //reporter.SendReports();

			////// ===========================================  StrongCoupling2 =============================================================
			//// Для начала зарегистрируем связи
			//ServiceLocator.RegisterService<IReportBuilder>(typeof(ReportBuilder));
			//ServiceLocator.RegisterService<IReportSender>(typeof(EmailReportSender));

			//var reporter = new Reporter();
			//reporter.SendReports();

			////// ===========================================  RectangleExample =============================================================
			//Rectangle r = new Square();
			//r.Width = 3;
			//r.Height = 2;
			//// и вот тут возникает неприятность - area = 4.  Надо разобраться в чем проблема
			//int area = r.CalculateRectangleArea();

		}
	}

	

}
