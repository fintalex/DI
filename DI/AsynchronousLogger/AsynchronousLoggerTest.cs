using System;
using System.Threading;
using NUnit.Framework;
namespace AsynchronousLogger
{
    [TestFixture]
    public class TestLog
    {
        private AsynchronousLogger logger;
        private int messagesLogged;
        [SetUp]
        protected void SetUp()
        {
            messagesLogged = 0;
            logger = new AsynchronousLogger(Console.Out);
            Pause();
        }
        [TearDown]
        protected void TearDown()
        {
            logger.Stop();
        }
        [Test]
        public void OneMessage()
        {
            logger.LogMessage("одно сообщение");
            CheckMessagesFlowToLog(1);
        }
        [Test]
        public void TwoConsecutiveMessages()
        {
            logger.LogMessage("другое");
            logger.LogMessage("и еще одно");
            CheckMessagesFlowToLog(2);
        }
        [Test]
        public void ManyMessages()
        {
            for (int i = 0; i < 10; i++)
            {
                logger.LogMessage(string.Format("сообщение:{0}", i));
                CheckMessagesFlowToLog(1);
            }
        }
        private void CheckMessagesFlowToLog(int queued)
        {
            CheckQueuedAndLogged(queued, messagesLogged);
            Pause();
            messagesLogged += queued;
            CheckQueuedAndLogged(0, messagesLogged);
        }
        private void CheckQueuedAndLogged(int queued, int logged)
        {
            Assert.AreEqual(queued, logger.MessagesInQueue(), "в очереди");
            Assert.AreEqual(logged, logger.MessagesLogged(), "зарегистрировано");
        }
        private void Pause()
        {
            Thread.Sleep(50);
        }
    }
}