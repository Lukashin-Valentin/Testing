using System;
using System.Configuration;
using System.Threading;

namespace Test
{
    public class Program
    {
        #region = МЕТОДЫ - Процедуры

        /// <summary>Главный метод приложения
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            fLog._mLog("Начало выполнения приложения");

            Console.WriteLine("хост:     " + fHost);
            fLog._mLog(" хост:     " + fHost);
            Console.WriteLine("период:   " + fInterval.ToString());
            fLog._mLog(" период:   " + fInterval.ToString());
            Console.WriteLine("протокол: " + fProtocolType);
            fLog._mLog(" протокол: " + fProtocolType);
            Console.WriteLine("");

            TimerCallback tm = new TimerCallback(mPinging);
            _cTimer = new Timer(tm, 0, 0, fInterval);

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                fLog._mLog("Завершение выполнения приложения");
            }
        }
        /// <summary>Выполнение ping-a
        /// </summary>
        /// <param name="pObject"></param>
        public static void mPinging(object pObject)
        {
            tstPingProcess vPingProcess = new tstPingProcess();
            vPingProcess._mGo(fHost, fProtocolType, fInterval);
        }

        #endregion = МЕТОДЫ - Процедуры

        #region = ПОЛЯ - Внутренние

        /// <summary>Объект для протоколирования событий приложения
        /// </summary>
        private static tstLog fLog = new tstLog();
        /// <summary>Объект таймера
        /// </summary>
        private static Timer _cTimer;
        /// <summary>Вид используемого протокола 
        /// </summary>
        private static string fProtocolType = ConfigurationManager.AppSettings["protocol"];
        /// <summary>Тестируемый хост
        /// </summary>
        private static string fHost = ConfigurationManager.AppSettings["host"];
        /// <summary>Период проверки
        /// </summary>
        private static int fInterval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]);

        #endregion = ПОЛЯ - Внутренние
    }
}
