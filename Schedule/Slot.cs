using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class State
    {
        private char _value;

        public char Value { get => _value; set => _value = value; }

        public bool HW { get => (Value & 1) != 0; }

        public bool CH { get => (Value & 2) != 0; }

        public bool WF { get => (Value & 4) != 0; }

        public bool IH { get => (Value & 8) != 0; }

        public State() : this(0) { }

        public State(int val) { Value = (char)val; }

        public State(int hw, int ch, int wf, int ih) { Value = (char)(hw + (ch << 1) + (wf << 2) + (ih << 3)); }

        public override string ToString() { return (HW ? "HW " : "") + (CH ? "CH " : "") + (WF ? "WIFI " : "") + (IH ? "IH " : ""); }
    }

    public class Time
    {
        private int _minute;
        private int _hour;

        public int Minute { get => _minute; set => _minute = value; }
        public int Hour { get => _hour; set => _hour = value; }
        
        public int IntTime { get => Hour * 60 + Minute; set { Hour = value / 60; Minute = value % 60; } }

        public Time() : this(0) { }
        public Time(int time) { IntTime = time; }
        public Time(int hour, int minute) { Minute = minute; Hour = hour; }

        public override string ToString() { return (Hour < 10 ? "0" : "") + Convert.ToString(Hour) + ":" + (Minute < 10 ? "0" : "") + Convert.ToString(Minute); }
    }

    public class Slot
    {
        private State _state;
        private int _weekday;
        private Time _start;
        private Time _finish;

        public State State { get => _state; set => _state = value; }
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
                    case 1:
                        return "Monday   ";
                    case 2:
                        return "Tuesday  ";
                    case 3:
                        return "Wednesday";
                    case 4:
                        return "Thursday ";
                    case 5:
                        return "Friday   ";
                    case 6:
                        return "Saturday ";
                    default:
                        return "INVALID DAY";
                }
            }
        }

        public Slot() : this(0, new Time(), new Time(), new State()) { }
        public Slot(int day, Time start, Time finish, State state) { State = state; Day = day; Start = start; Finish = finish; }

        public Slot(Slot s) { State = s.State; Start = s.Start; Finish = s.Finish; Day = s.Day; }

        public override string ToString() { return DayString + " " + Start.ToString() + " " + Finish.ToString() + " " + State.ToString(); }
    }
}
