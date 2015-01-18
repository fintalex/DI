using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongCoupling
{
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
    }
    public interface IReportSender
    {
        void Send(Report report);
    }

    // вместо того чтобы напрямую создавать а потом вызывать методы экземпляров класса
    // мы просто передаем Их ( обязательно они должны будут реализовывыть интерфейс) в конструктор Reporter
    public class Reporter
    {
        private readonly IReportBuilder reportbuilder;
        private readonly IReportSender reportSender;
        public Reporter (IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this.reportbuilder = reportbuilder;
            this.reportSender = reportSender;
        }
        public void SendReports()
        {
            IList<Report> reports = reportbuilder.CreateReports();
            if (reports.Count == 0)
                throw new Exception();
            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }
    }

    public class Report
    {
        // some fields of reports
    }

    // теперь если мы хотим отпаравлять отчеты через Sms - 
    // надо просто создать класс реализующий интерфейс - и передавать его в конструктор Reporter
    public class ReportBuilder : IReportBuilder
    {
        public IList<Report> CreateReports()
        {
            List<Report> repList = new List<Report>();
            return repList;
        }
    }
    public class EmailReportSender : IReportSender
    {
        public void Send(Report report)
        {
            // doing something for sending email
        }
    }
}


namespace StrongCoupling2
{
    //Нам нужен объект, который будет хранить информацию о том, что интерфейсу IReportSender соответствует реализация EmailReportSender. 
    //Назовем этот объект ServiceLocator. Связь интерфейса и реализации он будет хранить во внутреннем словаре:
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Type> services = new Dictionary<Type, Type>();
        public static void RegisterService<T>(Type service)
        {
            services[typeof(T)] = service;
        }
        public static T Resolve<T>()
        {
            return (T)Activator.CreateInstance(services[typeof(T)]);
        }
    }
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
    }
    public interface IReportSender
    {
        void Send(Report report);
    }

    // вместо того чтобы напрямую создавать а потом вызывать методы экземпляров класса
    // мы просто передаем Их ( обязательно они должны будут реализовывыть интерфейс) в конструктор Reporter
    public class Reporter
    {
        private readonly IReportBuilder reportbuilder;
        private readonly IReportSender reportSender;
        public Reporter()
            : this(ServiceLocator.Resolve<IReportBuilder>(), ServiceLocator.Resolve<IReportSender>())
        { }
        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this.reportbuilder = reportbuilder;
            this.reportSender = reportSender;
        }
        public void SendReports()
        {
            IList<Report> reports = reportbuilder.CreateReports();
            if (reports.Count == 0)
                throw new Exception();
            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }
    }

    public class Report
    {
        // some fields of reports
    }

    // теперь если мы хотим отпаравлять отчеты через Sms - 
    // надо просто создать класс реализующий интерфейс - и передавать его в конструктор Reporter
    public class ReportBuilder : IReportBuilder
    {
        public IList<Report> CreateReports()
        {
            List<Report> repList = new List<Report>();
            return repList;
        }
    }
    public class EmailReportSender : IReportSender
    {
        public void Send(Report report)
        {
            // doing something for sending email
        }
    }
}