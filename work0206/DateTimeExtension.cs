using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work0206
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 取得下一個整點時間
        /// </summary>
        /// <param name="insertDateTime"></param>
        /// <returns></returns>
        public static DateTime GetNextRoundDateTime(this DateTime insertDateTime)
        {
            var tempTime = insertDateTime.TimeOfDay;//去除日期             
               
            double ceilingNum = Math.Ceiling(tempTime.TotalHours);//無條件進入

            if(ceilingNum == 24)
            {
                ceilingNum = 0;
                insertDateTime= insertDateTime.AddDays(1);
            }

            return new DateTime(insertDateTime.Year, insertDateTime.Month, insertDateTime.Day, (int)ceilingNum, 0, 0);
            
        }
        /// <summary>
        /// 取得下一個刻鐘整點時間
        /// </summary>
        /// <param name="insertDateTime"></param>
        /// <returns></returns>
        public static DateTime GetQuarterRoundDateTime(this DateTime insertDateTime)
        {
            var tempTime = insertDateTime.TimeOfDay;//去除日期             
            int mins = tempTime.Minutes;
            int exactDivision = mins % 15;

            if (tempTime.Milliseconds == 0 && exactDivision == 0 && tempTime.Seconds == 0)//1刻鐘整
                return insertDateTime;            
           
            int resultMins = ((mins / 15) + 1) * 15;

            if (resultMins == 60)
            {
                resultMins = 0;
                insertDateTime = insertDateTime.AddHours(1);                
            }

            return new DateTime(insertDateTime.Year, insertDateTime.Month, insertDateTime.Day, insertDateTime.Hour, resultMins, 0);

        }
    }
}
