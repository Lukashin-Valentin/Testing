using System;

namespace Test
{
    public class tstPingProcess
    {
        #region = МЕТОДЫ - Процедуры

        public bool _mGo(string fHost, string fProtocolType, int fInterval)
        {
            bool vStatus = false;
            tstPing vPing = new tstPing();
            string vHttpStatus = ""; // Статус соединения по Http

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Ping...         ");
            //Thread.Sleep(300);
            switch (fProtocolType)
            {
                case "ICMP":
                    vPing = new tstPingICMP();
                    break;
                case "HTTP":
                    vPing = new tstPingHTTP();
                    vHttpStatus = "[" + (vPing as tstPingHTTP)._fStatusCode + "]";
                    break;
                default:
                    vPing = new tstPingTCP();
                    break;
            } // Выбор протоколов

            vStatus = vPing._mPing(fHost);
            if (fPingFirst == true)
            {
                if (vStatus == true)
                    fLog._mLog(" " + fHost + " OK " + vHttpStatus);
                else
                    fLog._mLog(" " + fHost + " FAILED " + vHttpStatus);
                fPingFirst = false;
            }
            else
            {
                if (vStatus != fStatusPreview)
                {
                    if (vStatus == true)
                        fLog._mLog(" " + fHost + " OK " + vHttpStatus);
                    else
                        fLog._mLog(" " + fHost + " FAILED " + vHttpStatus);
                }
            }
            fStatusPreview = vStatus;

            Console.SetCursorPosition(0, 4);
            if (vStatus == true)
                Console.WriteLine("Ping      OK");
            else
                Console.WriteLine("Ping      FAILED");
            Console.CursorVisible = false;

            return true;
        }

        #endregion = МЕТОДЫ - Процедуры

        #region = ПОЛЯ - Внутренние

        private bool fPingFirst = true;
        private tstLog fLog = new tstLog();
        private bool fStatusPreview = false;

        #endregion  = ПОЛЯ - Внутренние
    }
}
