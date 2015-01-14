using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    // простой приницип нарушения открытости закрытости -  использование конкретный объектов без абстакций
    public class Logger
    {
        public void Log (string logText)
        {
             // save log in file
        }
    }

    public class SmtpMailer
    {
        private readonly Logger logger;
        public SmtpMailer()
        {
            logger = new Logger();
        }
        public void SendMessage(string message)
        {
            // напрямую используем экземпляр объекта Logger
            logger.Log(string.Format("Sent '{0}'", message));
        }
    }

    // остальные классы тожк использую Logger
    // и казалось бы все хорошо, используй да используй
    // но проблема возникает если мы хотим писать логи в базу
    public class DatabasseLogger
    {
        public void Log(string logText)
        {
            // сохранить дог в базу данных
        }
    }
    
    // И вот теперь мы например хотим изменить класс SmtpMailer 
    // и нам приходится делать следующее
    public class SmtpMailer2
    {
        private readonly DatabasseLogger logger;
        public SmtpMailer2 ()
        {
            logger = new DatabasseLogger();
        }
        public void SendMessage (string message)
        {
            // отсылка сообщения
            logger.Log(string.Format("Sent '{0}'", message));
        }
    }
}
