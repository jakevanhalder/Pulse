using PulseWeb.Models;

namespace PulseWeb.Repository
{
    public class CalendarManager
    {
        //main function to arrange each details of day into a month, function returns a list of weeks for a month
        public WeekForMonth GetCalender(int month, int year)
        {

            WeekForMonth weeks = new WeekForMonth();
            weeks.Week1 = new List<Day>();
            weeks.Week2 = new List<Day>();
            weeks.Week3 = new List<Day>();
            weeks.Week4 = new List<Day>();
            weeks.Week5 = new List<Day>();
            weeks.Week6 = new List<Day>();

            List<DateTime> dt = new List<DateTime>();
            dt = GetDates(year, month);

            foreach (DateTime day in dt)
            {
                switch (GetWeekOfMonth(day))
                {
                    case 1:
                        Day dy1 = new Day();

                        dy1.Date = day;
                        dy1._Date = day.ToShortDateString();
                        dy1.dateStr = day.ToString("MM/dd/yyyy");
                        dy1.dtDay = day.Day;
                        dy1.daycolumn = GetDateInfo(dy1.Date);
                        weeks.Week1.Add(dy1);
                        break;
                    case 2:
                        Day dy2 = new Day();
                        dy2.Date = day;
                        dy2._Date = day.ToShortDateString();
                        dy2.dateStr = day.ToString("MM/dd/yyyy");
                        dy2.dtDay = day.Day;
                        dy2.daycolumn = GetDateInfo(dy2.Date);
                        weeks.Week2.Add(dy2);
                        break;
                    case 3:
                        Day dy3 = new Day();
                        dy3.Date = day;
                        dy3._Date = day.ToShortDateString();
                        dy3.dateStr = day.ToString("MM/dd/yyyy");
                        dy3.dtDay = day.Day;
                        dy3.daycolumn = GetDateInfo(dy3.Date);
                        weeks.Week3.Add(dy3);
                        break;
                    case 4:
                        Day dy4 = new Day();
                        dy4.Date = day;
                        dy4._Date = day.ToShortDateString();
                        dy4.dateStr = day.ToString("MM/dd/yyyy");
                        dy4.dtDay = day.Day;
                        dy4.daycolumn = GetDateInfo(dy4.Date);
                        weeks.Week4.Add(dy4);
                        break;
                    case 5:
                        Day dy5 = new Day();
                        dy5.Date = day;
                        dy5._Date = day.ToShortDateString();
                        dy5.dateStr = day.ToString("MM/dd/yyyy");
                        dy5.dtDay = day.Day;
                        dy5.daycolumn = GetDateInfo(dy5.Date);
                        weeks.Week5.Add(dy5);
                        break;
                    case 6:
                        Day dy6 = new Day();
                        dy6.Date = day;
                        dy6._Date = day.ToShortDateString();
                        dy6.dateStr = day.ToString("MM/dd/yyyy");
                        dy6.dtDay = day.Day;
                        dy6.daycolumn = GetDateInfo(dy6.Date);
                        weeks.Week6.Add(dy6);
                        break;
                };
            }

            while (weeks.Week1.Count < 7) // not starting from sunday
            {
                Day dy = null;
                weeks.Week1.Insert(0, dy);
            }

            if (month == 12)
            {
                weeks.nextMonth = (01).ToString() + "/" + (year + 1).ToString();
                weeks.prevMonth = (month - 1).ToString() + "/" + (year).ToString();
            }
            else if (month == 1)
            {
                weeks.nextMonth = (month + 1).ToString() + "/" + (year).ToString();
                weeks.prevMonth = (12).ToString() + "/" + (year - 1).ToString();
            }
            else
            {
                weeks.nextMonth = (month + 1).ToString() + "/" + (year).ToString();
                weeks.prevMonth = (month - 1).ToString() + "/" + (year).ToString();
            }

            return weeks;
        }

        //get all dates for a month for the year specified
        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
            .Select(day => new DateTime(year, month, day)) // Map each day to a date
            .ToList();
        }

        //get number of week for the selected month by passing in a date value
        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);
            while (date.Date.AddDays(1).DayOfWeek != DayOfWeek.Sunday)
                date = date.AddDays(1);
            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        //translate each day to a day number for mapping to week
        public int GetDateInfo(DateTime now)
        {
            int dayNumber = 0;
            DateTime dt = now.Date;
            string dayStr = Convert.ToString(dt.DayOfWeek);

            if (dayStr.ToLower() == "sunday")
            {
                dayNumber = 0;
            }
            else if (dayStr.ToLower() == "monday")
            {
                dayNumber = 1;
            }
            else if (dayStr.ToLower() == "tuesday")
            {
                dayNumber = 2;
            }
            else if (dayStr.ToLower() == "wednesday")
            {
                dayNumber = 3;
            }
            else if (dayStr.ToLower() == "thursday")
            {
                dayNumber = 4;
            }
            else if (dayStr.ToLower() == "friday")
            {
                dayNumber = 5;
            }
            else if (dayStr.ToLower() == "saturday")
            {
                dayNumber = 6;
            }
            return dayNumber;
        }
    }
}
