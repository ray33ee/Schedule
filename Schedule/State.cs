namespace Schedule
{
    public class MinuteState
    {
        private char _value;

        public char Value { get => _value; set => _value = value; }

        public bool HW { get => (Value & 1) != 0; }

        public bool CH { get => (Value & 2) != 0; }

        public bool WF { get => (Value & 4) != 0; }

        public bool IH { get => (Value & 8) != 0; }

        public MinuteState() : this(0) { }

        public MinuteState(int val) { Value = (char)val; }

        public MinuteState(int hw, int ch, int wf, int ih) { Value = (char)(hw + (ch << 1) + (wf << 2) + (ih << 3)); }

        public override string ToString() { return (HW ? "HW " : "") + (CH ? "CH " : "") + (WF ? "WIFI " : "") + (IH ? "IH " : ""); }
    }
}
