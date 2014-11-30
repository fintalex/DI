using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CustomerUI
{
    // UI layer
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<Customer>();
            objContainer.RegisterType<IDal, SQLServerDal>();
            objContainer.RegisterType<IDal, OracleDal>();


            Customer obj = objContainer.Resolve<Customer>();
            obj.CustomerName = "test";
            obj.Add();

        }
    }

    // Middle layer 
    public class Customer
    {
        private IDal Odal;
        public string CustomerName { get; set; }
        public Customer (IDal iobj)
        {
            Odal = iobj;
        }
        public void Add()
        {   
            Odal.Add();
        }
    }



    public interface IDal
    {
        void Add();
    }
    // dal - data access layer
    public class SQLServerDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql Server inserted");
        }
    }

    // Oracle 
    public class OracleDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql Server inserted");
        }
    }


}
