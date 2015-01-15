using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ПРИНЦИП РАЗДЕЛЕНИЯ ИНТЕРФЕЙСОВ
// клиенты не должны зависеть от методов которые они используют
// Яркий пример - если мы используем абстрактый какой то класс в качестве базового
// и нам надо реализовать 27 абстрактных методов. Но нам эти все методы не фиг сдались.
namespace TheInterfaceSegregationPrinciple
{
	// пример с лишней абстракцией в наследовании
	public abstract class EntityAuditor
	{
		public void AuditEntityFieldSet()
		{
			CreateLogRow();
		}
		protected abstract string CreateLogRow();
	}
	public class ProductAuditor : EntityAuditor
	{
		protected override string CreateLogRow()
		{
			return "Делаем лог по продукту";
		}
	}
	// Сейчас можем добавлять еще наследников и все ок
}


// но что если в методе AuditEntityFieldSet нам нужно 
// вызвать еще один метод UpdateDuplicates
namespace TheInterfaceSegregationPrinciple2
{
	// пример с лишней абстракцией в наследовании
	public abstract class EntityAuditor
	{
		public void AuditEntityFieldSet()
		{
			CreateLogRow();
			UpdateDuplicates();
		}
		protected abstract string CreateLogRow();
		protected abstract void UpdateDuplicates();
	}

	// после того как в базовом классе появился новый абстрактный метод
	// его должны переопределить все наследники классы
	public class ProductAuditor : EntityAuditor
	{
		protected override string CreateLogRow()
		{
			return "Делаем лог по продукту";
		}
		protected override void UpdateDuplicates()
		{
			// выполняем какие то действия 
		}
	}
	// и те же самые методы мы должны переопределить в другом наследнике
	public class AccountAuditor : EntityAuditor
	{
		protected override string CreateLogRow()
		{
			return "Делаем лог по аккаунту";
		}
		protected override void UpdateDuplicates()
		{
			// выполняем какие то действия 
		}
	}


}

// а теперь решение
// а в данном случае решение простое - в C# мы можем заменить abstract на virtual
// и тогда наследники не обязаны переопределять этот метод
// но ему надо будет написать какую-нибудь реализацию в базовом методе
namespace TheInterfaceSegregationPrinciple3
{
	// пример с лишней абстракцией в наследовании
	public abstract class EntityAuditor
	{
		public void AuditEntityFieldSet()
		{
			CreateLogRow();
			UpdateDuplicates();
		}
		protected abstract string CreateLogRow();
		protected virtual void UpdateDuplicates()
		{ }
	}

	// после того как в базовом классе появился новый абстрактный метод
	// его должны переопределить все наследники классы
	public class ProductAuditor : EntityAuditor
	{
		protected override string CreateLogRow()
		{
			return "Делаем лог по продукту";
		}
		protected override void UpdateDuplicates()
		{
			// выполняем какие то действия 
		}
	}
	// и те же самые методы мы должны переопределить в другом наследнике
	public class AccountAuditor : EntityAuditor
	{
		protected override string CreateLogRow()
		{
			return "Делаем лог по аккаунту";
		}
	}


}
