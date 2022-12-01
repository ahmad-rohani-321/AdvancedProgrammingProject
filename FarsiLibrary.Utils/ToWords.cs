using System;

namespace FarsiLibrary.Utils
{
    /// <summary>
    /// Classes to convert a number to its persian written form. It accepts both an Integer or Long as input parameter.
    /// </summary>
    /// <exception>Thrown when input number is larger than 999999999999</exception>
    /// <example>
    /// An example on how to convert a Integer number to words.
    /// <code>
    ///		class MyClass 
    ///     {
    ///		   public static void Main() 
    ///        {
    ///		      Console.WriteLine(FarsiLibrary.Utils.ToWords.ToString(1452));
    ///		   }
    ///		}
    /// </code>
    /// </example>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static class ToWords
    {
        private static readonly string[] cvtText = new string[1000];

        static ToWords()
        {
            cvtText[0] = "صفر";
            cvtText[1] = "یو";
            cvtText[2] = "دوه";
            cvtText[3] = "درې";
            cvtText[4] = "څلور";
            cvtText[5] = "پنځه";
            cvtText[6] = "شپږ";
            cvtText[7] = "اوه";
            cvtText[8] = "اته";
            cvtText[9] = "نهه";
            cvtText[10] = "لس";
            cvtText[11] = "یوولس";
            cvtText[12] = "دوولس";
            cvtText[13] = "دیارلس";
            cvtText[14] = "څوارلس";
            cvtText[15] = "پنځلس";
            cvtText[16] = "شپاړس";
            cvtText[17] = "اووه لس";
            cvtText[18] = "اته لس";
            cvtText[19] = "نولس";
            cvtText[20] = "شل";
            cvtText[21] = "دېرش";
            cvtText[22] = "څلوېښت";
            cvtText[23] = "پنځوس";
            cvtText[24] = "شپېته";
            cvtText[25] = "اویا";
            cvtText[26] = "اتیا";
            cvtText[27] = "نوي";
            cvtText[28] = "سل";
            cvtText[29] = "زر";
            cvtText[30] = "میلیون";
            cvtText[31] = "میلیارد";
            cvtText[100] = "سل";
            cvtText[200] = "دوه سوه";
            cvtText[300] = "درې سوه";
            cvtText[400] = "څلور سوه";
            cvtText[500] = "پنځه سوه";
            cvtText[600] = "شپږ سوه";
            cvtText[700] = "اوه سوه";
            cvtText[800] = "اته سوه";
            cvtText[900] = "نه سوه";
        }

        private static string cvt100(long Number)
        {
            var x = (int)Number;
            var result = string.Empty;
            int t;

            System.Diagnostics.Debug.Assert(x < 999);

            if (x > 99)
            {
                t = x / 100;
                switch (t)
                {
                    case 1:
                        result = cvtText[100];
                        break;
                    case 2:
                        result = cvtText[200];
                        break;
                    case 3:
                        result = cvtText[300];
                        break;
                    case 4:
                        result = cvtText[400];
                        break;
                    case 5:
                        result = cvtText[500];
                        break;
                    case 6:
                        result = cvtText[600];
                        break;
                    case 7:
                        result = cvtText[700];
                        break;
                    case 8:
                        result = cvtText[800];
                        break;
                    case 9:
                        result = cvtText[900];
                        break;
                }

                x = x - (t * 100);

                if (x <= 0)
                {
                    return result;
                }

                result += String.Format(" {0} ", "او"); ;
            }

            if (x > 20)
            {
                t = x / 10;
                result = result + cvtText[t + 18];
                x = x - (t * 10);

                if (x <= 0)
                {
                    return result;
                }

                result += String.Format("{0}", " او "); ;
            }

            if (x > 0)
            {
                result += cvtText[x];
            }

            if (x == 0)
            {
                result += cvtText[0];
            }

            return result;
        }


        /// <overloads>Has two overloads.</overloads>
        /// <summary>Converts an integer number to its written form in Persian</summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ToString(int x)
        {
            return ToString(long.Parse(x.ToString()));
        }

        public static string ToString(double  x)
        {
            return ToString((long)x);
        }

        /// <summary>Converts a long number to its written form in Persian</summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ToString(long x)
        {
            long t;
            string result = string.Empty;

            if (x > 999999999999)
                throw new ArgumentOutOfRangeException("x", "Number is too large to process");

            if (x < 0)
                throw new ArgumentOutOfRangeException("x", "Number should be a positive value");

            if (x > 999999999)
            {
                t = x / 1000000000;
                result += cvt100(t) + " " + cvtText[31];
                x = x - (t * 1000000000);

                if (x <= 0)
                {
                    return result;
                }

                result += String.Format("{0}", " او ");
            }

            if (x > 999999)
            {
                t = x / 1000000;
                result += cvt100(t) + " " + cvtText[30];
                x = x - (t * 1000000);

                if (x <= 0)
                {
                    return result;
                }

                result += String.Format("{0}", " او ");
            }

            if (x > 999)
            {
                t = x / 1000;
                result += cvt100(t) + " " + cvtText[29];
                x = x - (t * 1000);

                if (x <= 0)
                {
                    return result;
                }

                result += String.Format("{0}", " او "); ;
            }

            if (x >= 0)
            {
                result += cvt100(x);
            }

            return result;
        }
    }
}
