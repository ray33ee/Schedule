namespace Schedule
{
    public class MinuteState
    {
        private char _value;

        public MinuteState(char val)
        {
            _value = val;
        }

        public MinuteState(int HW, int CH, int WF, int IH)
        {
            _value = (char)(HW + (CH << 1) + (WF << 2) + (IH << 3));
        }

        public char Value
        {
            get => _value;
            set => _value = value;
        }



        public bool HW
        {
            get => (Value & 1) == 0;
        }

        public bool CH
        {
            get => (Value & 2) == 0;
        }

        public bool WF
        {
            get => (Value & 4) == 0;
        }

        public bool IH
        {
            get => (Value & 8) == 0;
        }
    }
}
