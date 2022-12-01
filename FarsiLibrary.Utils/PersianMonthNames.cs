using System.Collections.Generic;

namespace FarsiLibrary.Utils
{
    internal class PersianMonthNames
    {
        #region Fields

        public string Farvardin = "وری";
        public string Ordibehesht = "غويئ";
        public string Khordad = "غبرګولی";
        public string Tir = "چنګاښ";
        public string Mordad = "زمری";
        public string Shahrivar = "وږی";
        public string Mehr = "تله";
        public string Aban = "لړم";
        public string Azar = "لېند";
        public string Day = "مرغومی";
        public string Bahman = "سلواغه";
        public string Esfand = "کب";
        private readonly List<string> months;
        private static PersianMonthNames instance;

        #endregion

        #region Ctor

        private PersianMonthNames()
        {
            months = new List<string>
                         {
                             Farvardin,
                             Ordibehesht,
                             Khordad,
                             Tir,
                             Mordad,
                             Shahrivar,
                             Mehr,
                             Aban,
                             Azar,
                             Day,
                             Bahman,
                             Esfand,
                             ""
                         };
        }

        #endregion

        #region Singleton

        public static PersianMonthNames Default
        {
            get
            {
                if(instance == null)
                    instance = new PersianMonthNames();

                return instance;
            }
        }

        #endregion

        #region Indexer

        internal List<string> Months
        {
            get { return months; }
        }

        public string this[int month]
        {
            get { return months[month]; }
        }

        #endregion
    }
}
