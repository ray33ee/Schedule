using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Time
    {
        private int _minute;
        private int _hour;

        public int Minute { get => _minute; set => _minute = value; }
        public int Hour { get => _hour; set => _hour = value; }
        
        public int IntTime { get => Hour * 60 + Minute; set { Hour = value / 60; Minute = value % 60; } }

        public Time() : this(0) { }
        public Time(int time) { IntTime = time; }

        public override string ToString() { return Convert.ToString(Hour) + ":" + Convert.ToString(Minute); }
    }

    class Slot
    {
        private MinuteState _state;
        private int _weekday;
        private Time _start;
        private Time _finish;

        public MinuteState State { get => _state; set => _state = value; }
        public int Day { get => _weekday; set => _weekday = value; }
        public Time Start { get => _start; set => _start = value; }
        public Time Finish { get => _finish; set => _finish = value; }

        public string DayString
        {
            get
            {
                switch (Day)
                {
                    case 0:
                        return "Sunday   ";
                        break;
                    case 1:
                        return "Monday   ";
                        break;
                    case 2:
                        return "Tuesday  ";
                        break;
                    case 3:
                        return "Wednesday";
                        break;
                    case 4:
                        return "Thursday ";
                        break;
                    case 5:
                        return "Friday   ";
                        break;
                    case 6:
                        return "Saturday ";
                        break;
                    default:
                        return "INVALID DAY";
                }
            }
        }

        public Slot(int day, Time start, Time finish, MinuteState state) { State = state; Day = day; Start = start; Finish = finish; }
        
        public override string ToString() { return DayString + " " + Start.ToString() + " " + Finish.ToString() + " " + State.ToString(); }
    }
}
