using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>Тестирование класса протоколирования событий
        /// </summary>
        /// <param name="pMessage">Сообщение</param>
        [TestMethod]
        [DataRow("тестирование класса протоколирования событий")]
        public void TestMethodLog(string pMessage)
        {
            var vLog = new tstLog();
            Assert.AreEqual(true, vLog._mLog(pMessage));
        }
        /// <summary>Тестирование класса вызова объектов для тестирования
        /// </summary>
        /// <param name="pHost">Хост</param>
        /// <param name="pProtocolType">Вид протокола</param>
        /// <param name="pInterval">Период тестирования</param>
        [TestMethod]
        [DataRow("www.microsoft.com", "ICMP", 1)]
        [DataRow("qqqqq.ru", "ICMP", 1)]
        [DataRow(".ru", "ICMP", 1)]
        [DataRow("ya", "ICMP", 1)]
        [DataRow("", "ICMP", 1)]
        public void TestMethodAll(string pHost, string pProtocolType, int pInterval)
        {
            var vPing = new tstPingProcess();
            Assert.AreEqual(true, vPing._mGo(pHost, pProtocolType, pInterval));
        }
        /// <summary>Тестирование класса по протоколу ICMP
        /// </summary>
        /// <param name="pHost"></param>
        [TestMethod]
        [DataRow("www.microsoft.com")]
        [DataRow("qqqqq.ru")]
        [DataRow(".ru")]
        [DataRow("ya")]
        [DataRow("")]
        public void TestMethodICMP(string pHost)
        {
            var vPing = new tstPingICMP();
            Assert.AreEqual(true, vPing._mPing(pHost));
        }
        /// <summary>Тестирование класса по протоколу HTTP
        /// </summary>
        /// <param name="pHost"></param>
        [TestMethod]
        [DataRow("www.microsoft.com")]
        [DataRow("qqqqq.ru")]
        [DataRow(".ru")]
        [DataRow("ya")]
        [DataRow("")]
        public void TestMethodHTTP(string pHost)
        {
            var vPing = new tstPingHTTP();
            Assert.AreEqual(true, vPing._mPing(pHost));
        }
        /// <summary>Тестирование класса по протоколу TCP
        /// </summary>
        /// <param name="pHost"></param>
        [TestMethod]
        [DataRow("www.microsoft.com")]
        [DataRow("qqqqq.ru")]
        [DataRow(".ru")]
        [DataRow("ya")]
        [DataRow("")]
        public void TestMethodTCP(string pHost)
        {
            var vPing = new tstPingTCP();
            Assert.AreEqual(true, vPing._mPing(pHost));
        }
    }
}

