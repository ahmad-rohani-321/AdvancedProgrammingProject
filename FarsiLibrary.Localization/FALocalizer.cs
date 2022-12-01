namespace FarsiLibrary.Localization
{
    /// <summary>
    /// Farsi Localizer
    /// </summary>
    public class FALocalizer : BaseLocalizer
    {
        public override string GetLocalizedString(StringID id)
        {
            switch (id)
            {
                case StringID.Empty: return string.Empty;
                case StringID.Numbers_0: return "۰";
                case StringID.Numbers_1: return "۱";
                case StringID.Numbers_2: return "۲";
                case StringID.Numbers_3: return "۳";
                case StringID.Numbers_4: return "۴";
                case StringID.Numbers_5: return "۵";
                case StringID.Numbers_6: return "۶";
                case StringID.Numbers_7: return "۷";
                case StringID.Numbers_8: return "۸";
                case StringID.Numbers_9: return "۹";

                case StringID.FADateTextBox_Required: return "فيلد حتمي دی";
                case StringID.FAMonthView_None: return "تش";
                case StringID.FAMonthView_Today: return "نن ورځ";

                case StringID.PersianDate_InvalidDateFormat: return "د نېټې جوړښت سم نه دی";
                case StringID.PersianDate_InvalidDateTime: return "ناسم نېټه";
                case StringID.PersianDate_InvalidDateTimeLength: return "ناسم نېټه";
                case StringID.PersianDate_InvalidDay: return "ناسم ورځ";
                case StringID.PersianDate_InvalidEra: return "ناسم حدود";
                case StringID.PersianDate_InvalidFourDigitYear: return "داخل سوی عدد کال ته نه تغیر کیږي";
                case StringID.PersianDate_InvalidHour: return "ساعت صحیح نه دی";
                case StringID.PersianDate_InvalidLeapYear: return "داخل سوی کال صحیح نه دی، د ورځو تعداد اصلاح کړئ";
                case StringID.PersianDate_InvalidMinute: return "ناسم دقیقې";
                case StringID.PersianDate_InvalidMonth: return "ناسم میاشت";
                case StringID.PersianDate_InvalidMonthDay: return "میاشت او ورځ صحیح نه ده";
                case StringID.PersianDate_InvalidSecond: return "ثانیه صحیح نه ده";
                case StringID.PersianDate_InvalidTimeFormat: return "د وخت جوړښت صحیح نه دی";
                case StringID.PersianDate_InvalidYear: return "کال مو ناسم دی";

                case StringID.Validation_Cancel: return "ناسم عدد";
                case StringID.Validation_NotValid: return "ناسم عدد";
                case StringID.Validation_Required: return "ضروري انتخاب، هیله ده قیمت داخل کړئ";
                case StringID.Validation_NullText: return "هیڅ قیمت نه دی داخل سوی";

                case StringID.MessageBox_Ok: return "صحیح";
                case StringID.MessageBox_Cancel: return "لغو";
                case StringID.MessageBox_Abort: return "لغو";
                case StringID.MessageBox_Ignore: return "ادامه";
                case StringID.MessageBox_Retry: return "بیاځلی کوښښ";
                case StringID.MessageBox_No: return "نه";
                case StringID.MessageBox_Yes: return "هو";
                
                case StringID.Hour: return "ساعت";
                case StringID.Minute: return "دقیقه";
                case StringID.Second: return "ثانیه";
            }

            return "";
        }

        public override string GetFormatterString(FormatterStringID stringID)
        {
            switch (stringID)
            {
                case FormatterStringID.CenturyPattern: return "%n %u";
                case FormatterStringID.CenturyFuturePrefix: return "";
                case FormatterStringID.CenturyFutureSuffix: return "وروسته ";
                case FormatterStringID.CenturyPastPrefix: return "";
                case FormatterStringID.CenturyPastSuffix: return "مخکي ";
                case FormatterStringID.CenturyName: return "پېړی";
                case FormatterStringID.CenturyPluralName: return "پېړی";
                case FormatterStringID.DayPattern: return "%n %u";
                case FormatterStringID.DayFuturePrefix: return "";
                case FormatterStringID.DayFutureSuffix: return "وروسته ";
                case FormatterStringID.DayPastPrefix: return "";
                case FormatterStringID.DayPastSuffix: return "مخکي ";
                case FormatterStringID.DayName: return "ورځ";
                case FormatterStringID.DayPluralName: return "ورځ";
                case FormatterStringID.DecadePattern: return "%n %u";
                case FormatterStringID.DecadeFuturePrefix: return "";
                case FormatterStringID.DecadeFutureSuffix: return "وروسته ";
                case FormatterStringID.DecadePastPrefix: return "";
                case FormatterStringID.DecadePastSuffix: return "مخکي ";
                case FormatterStringID.DecadeName: return "دهه";
                case FormatterStringID.DecadePluralName: return "دهه";
                case FormatterStringID.HourPattern: return "%n %u";
                case FormatterStringID.HourFuturePrefix: return "";
                case FormatterStringID.HourFutureSuffix: return "وروسته ";
                case FormatterStringID.HourPastPrefix: return "";
                case FormatterStringID.HourPastSuffix: return "مخکي ";
                case FormatterStringID.HourName: return "ساعت";
                case FormatterStringID.HourPluralName: return "ساعت";
                case FormatterStringID.JustNowPattern: return "%u";
                case FormatterStringID.JustNowFuturePrefix: return "";
                case FormatterStringID.JustNowFutureSuffix: return "څو لحظې وروسته";
                case FormatterStringID.JustNowPastPrefix: return "څو لحظې مخکي";
                case FormatterStringID.JustNowPastSuffix: return "";
                case FormatterStringID.JustNowName: return "";
                case FormatterStringID.JustNowPluralName: return "";
                case FormatterStringID.MillenniumPattern: return "%n %u";
                case FormatterStringID.MillenniumFuturePrefix: return "";
                case FormatterStringID.MillenniumFutureSuffix: return "وروسته ";
                case FormatterStringID.MillenniumPastPrefix: return "";
                case FormatterStringID.MillenniumPastSuffix: return "مخکي ";
                case FormatterStringID.MillenniumName: return "صده";
                case FormatterStringID.MillenniumPluralName: return "صده";
                case FormatterStringID.MillisecondPattern: return "%n %u";
                case FormatterStringID.MillisecondFuturePrefix: return "";
                case FormatterStringID.MillisecondFutureSuffix: return "وروسته";
                case FormatterStringID.MillisecondPastPrefix: return "";
                case FormatterStringID.MillisecondPastSuffix: return "مخکي ";
                case FormatterStringID.MillisecondName: return "زرم ثانیه";
                case FormatterStringID.MillisecondPluralName: return "زرم ثانیه";
                case FormatterStringID.MinutePattern: return "%n %u";
                case FormatterStringID.MinuteFuturePrefix: return "";
                case FormatterStringID.MinuteFutureSuffix: return "وروسته ";
                case FormatterStringID.MinutePastPrefix: return "";
                case FormatterStringID.MinutePastSuffix: return "مخکي ";
                case FormatterStringID.MinuteName: return "دقیقه";
                case FormatterStringID.MinutePluralName: return "دقیقه";
                case FormatterStringID.MonthPattern: return "%n %u";
                case FormatterStringID.MonthFuturePrefix: return "";
                case FormatterStringID.MonthFutureSuffix: return "وروسته ";
                case FormatterStringID.MonthPastPrefix: return "";
                case FormatterStringID.MonthPastSuffix: return "مخکي ";
                case FormatterStringID.MonthName: return "میاشت";
                case FormatterStringID.MonthPluralName: return "میاشت";
                case FormatterStringID.SecondPattern: return "%n %u";
                case FormatterStringID.SecondFuturePrefix: return "";
                case FormatterStringID.SecondFutureSuffix: return "وروسته ";
                case FormatterStringID.SecondPastPrefix: return "";
                case FormatterStringID.SecondPastSuffix: return "مخکي ";
                case FormatterStringID.SecondName: return "ثانیه";
                case FormatterStringID.SecondPluralName: return "ثانیه";
                case FormatterStringID.WeekPattern: return "%n %u";
                case FormatterStringID.WeekFuturePrefix: return "";
                case FormatterStringID.WeekFutureSuffix: return "وروسته ";
                case FormatterStringID.WeekPastPrefix: return "";
                case FormatterStringID.WeekPastSuffix: return "مخکي ";
                case FormatterStringID.WeekName: return "اونۍ";
                case FormatterStringID.WeekPluralName: return "اونۍ";
                case FormatterStringID.YearPattern: return "%n %u";
                case FormatterStringID.YearFuturePrefix: return "";
                case FormatterStringID.YearFutureSuffix: return "وروسته ";
                case FormatterStringID.YearPastPrefix: return "";
                case FormatterStringID.YearPastSuffix: return "مخکي ";
                case FormatterStringID.YearName: return "کال";
                case FormatterStringID.YearPluralName: return "کال";
            }

            return string.Empty;
        }

    }
}
