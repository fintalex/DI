using System;
using System.Collections;
using System.IO;
using System.Threading;
namespace AsynchronousLogger
{
    public interface Logger
    {
        void LogMessage(String msg);
    }
    public class AsynchronousLogger : Logger
    {
        private ArrayList messages =
        ArrayList.Synchronized(new ArrayList());
        private Thread t;
        private bool running;
        private int logged;
        private TextWriter logStream;
        public AsynchronousLogger(TextWriter stream)
        {
            logStream = stream;
            running = true;
            t = new Thread(new ThreadStart(MainLoggerLoop));
            t.Priority = ThreadPriority.Lowest;
            t.Start();
        }
        private void MainLoggerLoop()
        {
            while (running)
            {
                LogQueuedMessages();
                SleepTillMoreMessagesQueued();
                Thread.Sleep(10); // Напомните, чтобы я объяснил это место.
            }
        }
        private void LogQueuedMessages()
        {
            while (MessagesInQueue() > 0)
                LogOneMessage();
        }
        private void LogOneMessage()
        {
            string msg = (string)messages[0];
            messages.RemoveAt(0);
            logStream.WriteLine(msg);
            logged++;
        }
        private void SleepTillMoreMessagesQueued()
        {
            lock (messages)
            {
                Monitor.Wait(messages);
            }
        }
        public void LogMessage(String msg)
        {
            messages.Add(msg);
            WakeLoggerThread();
        }
        public int MessagesInQueue()
        {
            return messages.Count;
        }
        public int MessagesLogged()
        {
            return logged;
        }
        public void Stop()
        {
            running = false;
            WakeLoggerThread();
            t.Join();
        }
        private void WakeLoggerThread()
        {
            lock (messages)
            {
                Monitor.PulseAll(messages);
            }
        }
    }
}