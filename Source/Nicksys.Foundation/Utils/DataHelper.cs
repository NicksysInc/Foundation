// ----------------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Nicksys.Foundation.Utils
{
    public static class DataHelper
    {
        public static bool IsValidDate(string date)
        {
            DateTime temp;

            return DateTime.TryParse(date, out temp);
        }

        public static bool IsValidDate(DateTime date)
        {
            return date != DateTime.MinValue;
        }

        public static bool IsValidGuid(string guidString)
        {
            Guid guid;
            
            return Guid.TryParse(guidString, out guid);
        }

        public static Guid ConvertToGuid(string guidString)
        {
            Guid guid;

            Guid.TryParse(guidString, out guid);

            return guid;
        }

        public static Guid ToGuid(this string guidString)
        {
            Guid guid;

            Guid.TryParse(guidString, out guid);

            return guid;
        }

        public static void GetWeekDates(DateTime selectedDate, out DateTime startDate, out DateTime endDate)
        {
            startDate = selectedDate;
            endDate = selectedDate;

            switch (selectedDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    startDate = selectedDate;
                    endDate = selectedDate.AddDays(6);
                    break;
                case DayOfWeek.Tuesday:
                    startDate = selectedDate.Subtract(new TimeSpan(1, 0, 0, 0));
                    endDate = selectedDate.AddDays(5);
                    break;
                case DayOfWeek.Wednesday:
                    startDate = selectedDate.Subtract(new TimeSpan(2, 0, 0, 0));
                    endDate = selectedDate.AddDays(4);
                    break;
                case DayOfWeek.Thursday:
                    startDate = selectedDate.Subtract(new TimeSpan(3, 0, 0, 0));
                    endDate = selectedDate.AddDays(3);
                    break;
                case DayOfWeek.Friday:
                    startDate = selectedDate.Subtract(new TimeSpan(4, 0, 0, 0));
                    endDate = selectedDate.AddDays(2);
                    break;
                case DayOfWeek.Saturday:
                    startDate = selectedDate.Subtract(new TimeSpan(5, 0, 0, 0));
                    endDate = selectedDate.AddDays(1);
                    break;
                case DayOfWeek.Sunday:
                    startDate = selectedDate.Subtract(new TimeSpan(6, 0, 0, 0));
                    endDate = selectedDate;
                    break;
            }
        }

        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var time = (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;

            return time;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch 
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }

        public static DateTime? ConvertDate(string date, string cultureCode)
        {
            DateTime? result = null;

            IFormatProvider culture = new CultureInfo(cultureCode);
            DateTime tryDateTime;

            if (DateTime.TryParse(date, culture, DateTimeStyles.None, out tryDateTime))
            {
                result = tryDateTime;
            }

            return result;
        }

        public static Image GetImage(byte[] byteArray)
        {
            Image photo = null;

            if (byteArray != null)
            {
                var stream = new MemoryStream(byteArray);
                if (stream.Length > 0)
                {
                    photo = Image.FromStream(stream);
                }
            }

            return photo;
        }

        public static byte[] GetByteArray(Stream stream)
        {
            var array = new byte[stream.Length];
            
            stream.Read(array, 0, array.Length);
            stream.Close();

            return array;
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
