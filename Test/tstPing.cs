namespace Test
{
    /// <summary>Родительский класс для Ping-а
    /// </summary>
    public class tstPing
    {
        #region = МЕТОДЫ - Процедуры

        /// <summary>Выполнение пинга
        /// </summary>
        /// <param name="pHost">Пингуемый хост</param>
        /// <returns>[true] - пинг выполнен, иначе - [fals]</returns>
        public virtual bool _mPing(string pHost)
        {
            return true;
        }

        #endregion = МЕТОДЫ - Процедуры

        #region = ПОЛЯ - Атрибуты

        /// <summary>Результат проверки
        /// </summary>
        public bool _fPingResult = false;

        #endregion = ПОЛЯ - Атрибуты
    }
}
