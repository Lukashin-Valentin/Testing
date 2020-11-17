using System;
using System.Net.Sockets;

namespace Test
{
    /// <summary>Класс для тестирования по протоколу TCP
    /// </summary>
    public class tstPingTCP : tstPing
    {
        #region = МЕТОДЫ - Процедуры

        /// <summary>Выполнение пинга
        /// </summary>
        /// <param name="pHost">Пингуемый хост</param>
        /// <returns>[true] - пинг выполнен, иначе - [fals]</returns>
        public override bool _mPing(string pHost)
        {
            _fPingResult = true;

            Socket vSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            vSocket.LingerState = new LingerOption(true, 2);
            vSocket.NoDelay = true;
            char[] vDelimiterChars = { ':' };
            string[] vHostChars = pHost.Split(vDelimiterChars);
            try
            {
                vSocket.Connect(vHostChars[0], int.Parse(vHostChars[1]));
            }
            catch (SocketException vSocketException)
            {
                _fPingResult = false;
            }
            catch (Exception vException)
            {
                _fPingResult = false;
            }
            finally
            {
                if (vSocket.Connected)
                {
                    vSocket.Close();
                    _fPingResult = true;
                }
                else
                {
                    _fPingResult = false;
                }
            }
            return true;
        }

        #endregion = МЕТОДЫ - Процедуры
    }
}
