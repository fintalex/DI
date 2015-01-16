using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatInterface
{
	// есть интерфейс ISpecification, и с помощью него можно узнать-
	// подходит ли продукт заявке - IsSuitable , и является ли полу продукта измененным - методы IsFieldChanged
	public interface ISpecification
	{
		bool IsSuitable(String product, String offer);
		bool IsFieldChanged(String product, String newValue);
	}
	// этот интерфейс является некоторым модулем который можно использовать.
	// и проблема в том что первый метод использует консольное приложение
	// а второй метод - класс хранилище

	/// Хранилице для продуктов
	public class ProductRepository
	{
		private ISpecification _spec;
		public ProductRepository(ISpecification spec)
		{
			_spec = spec;
		}
		public void Save(String product)
		{
			//
			_spec.IsFieldChanged("myProduct", "newValueForProduct");
		}
	}


	// программа расчета подходяхих продуктов
	public class Program
	{
		private ISpecification specification { get; set; }

		public void SomeMain()
		{
			specification.IsSuitable("myProduct", "myOffer");
		}
	}
	// и еще допустим написали как какую-то спецификацию
	public class ProductSpecification : ISpecification
	{
		public bool IsSuitable(string product, string offer)
		{
			throw new NotImplementedException();
		}

		public bool IsFieldChanged(string product, string newValue)
		{
			throw new NotImplementedException();
		}
	}

	// полученный результат не очень хороший, 
	// при изменении какой то логики в консольном приложении и методе IsSutable 
	// на прийдется изменять все классы которые уже реализовали этот интерфейс ISpecification.
	// например, если мы захотим добавить новый параметр в IsSutable!!!
}
