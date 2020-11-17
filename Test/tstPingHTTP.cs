using System.IO;
using System.Net;
using System.Text;

namespace Test
{
    /// <summary>Класс для тестирования по протоколу HTTP
    /// </summary>
    public class tstPingHTTP : tstPing
    {
        #region = МЕТОДЫ - Процедуры

        /// <summary>Выполнение пинга
        /// </summary>
        /// <param name="pHost">Пингуемый хост</param>
        /// <returns>[true] - пинг выполнен, иначе - [fals]</returns>
        public override bool _mPing(string pHost)
        {
            _fPingResult = true;
            HttpWebRequest vHttpWebRequest;
            WebResponse vWebResponse;

            try
            {
                vHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + pHost);
                vWebResponse = (HttpWebResponse)vHttpWebRequest.GetResponse();
            }
            catch
            {
                _fStatusCode = "400";
                _fPingResult = false;
                return true;
            }
            StreamReader vStreamReader = new StreamReader(vWebResponse.GetResponseStream(), Encoding.GetEncoding(1251));
            if (vStreamReader.ReadToEnd().Length > 0)
            {
                _fPingResult = true;
                _fStatusCode = "200"; // OK
            }
            else
            {
                _fPingResult = false;
                _fStatusCode = "204"; // Не содержимого
            }
            vWebResponse.Close();

            //WebProxy proxy = new WebProxy("192.168.0.100", 3128);
            //proxy.Credentials = new NetworkCredential("имя", "пароль");

            return true;
        }

        #endregion = МЕТОДЫ - Процедуры

        #region = ПОЛЯ - Атрибуты

        public string _fStatusCode = "200";

        #endregion = ПОЛЯ - Атрибуты
    }
}
