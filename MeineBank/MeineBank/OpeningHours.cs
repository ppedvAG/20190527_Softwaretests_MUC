using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineBank
{
    public struct Time
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }


    public class OpeningHours
    {
        private Dictionary<DayOfWeek, Time> openingTime = new Dictionary<DayOfWeek, Time>();

        public OpeningHours()
        {
            openingTime.Add(DayOfWeek.Monday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(19, 00, 00)
            });
            openingTime.Add(DayOfWeek.Tuesday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(19, 00, 00)
            });
            openingTime.Add(DayOfWeek.Wednesday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(19, 00, 00)
            });
            openingTime.Add(DayOfWeek.Thursday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(19, 00, 00)
            });
            openingTime.Add(DayOfWeek.Friday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(19, 00, 00)
            });
            openingTime.Add(DayOfWeek.Saturday, new Time
            {
                Start = new TimeSpan(10, 30, 00),
                End = new TimeSpan(14, 00, 00)
            });
        }

        public bool IsOpen(DateTime date)
        {
            if (openingTime.ContainsKey(date.DayOfWeek))
            {
                if (date.TimeOfDay >= openingTime[date.DayOfWeek].Start &&
                    date.TimeOfDay <  openingTime[date.DayOfWeek].End)
                    return true;
                else
                    return false;
            }
            else
                return false; // Alle Tage die nicht im Dict sind (z.B. Sonntag), sind zu !
        }
    }
}
