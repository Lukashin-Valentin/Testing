using System;
using System.IO;
using System.Text;

namespace Test
{
    /// <summary>Класс протоколирования событий приложения
    /// </summary>
    public class tstLog
    {
        // uyuyiuyiuyiuyiuyiu

        /// <summary>Протоколирование событий приложения
        /// </summary>
        /// <param name="pString">Протоколируемое сообщение</param>
        public bool _mLog(string pString)
        {
            FileStream vFileStream = new FileStream(Environment.CurrentDirectory + "log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            if (vFileStream != null)
            {
                string vLineContent = DateTime.Now.ToString() + " " + pString + "\n";
                int vLineLength = vLineContent.Length;
                byte[] vByteLine = new byte[vLineLength];
                vFileStream.Seek(0, SeekOrigin.End);
                vFileStream.Write(Encoding.Default.GetBytes(vLineContent), 0, vLineLength);
                vFileStream.Close();
            }

            return true;
        }
    }
}
