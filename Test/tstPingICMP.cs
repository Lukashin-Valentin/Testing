using System.Net.NetworkInformation;
using System.Text;

namespace Test
{
    /// <summary>Класс для тестирования по протоколу ICMP
    /// </summary>
    public class tstPingICMP : tstPing
    {
        #region = МЕТОДЫ - Процедуры

        /// <summary>Выполнение пинга
        /// </summary>
        /// <param name="pHost">Пингуемый хост</param>
        /// <returns>[true] - пинг выполнен, иначе - [fals]</returns>
        public override bool _mPing(string pHost)
        {
            _fPingResult = true;

            Ping vPing = new Ping();
            PingOptions vPingOptions = new PingOptions();
            vPingOptions.DontFragment = true;
            string vData = new string(' ', 32); 
            byte[] vBuffer = Encoding.ASCII.GetBytes(vData);
            int vTimeout = 120;
            try
            {
                PingReply reply = vPing.Send(pHost, vTimeout, vBuffer, vPingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    _fPingResult = true;
                }
                else
                {
                    _fPingResult = false;
                }
            }
            catch
            {
                _fPingResult = false;
            }
            vPing.Dispose();

            return true;
        }

        #endregion = МЕТОДЫ - Процедуры
    }
}
