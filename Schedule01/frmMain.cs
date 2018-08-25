using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Schedule
{
    public partial class frmMain : Form
    {
        private const int MINUTES_PER_DAY = 1500; //The number of minutes per day, rounded to the nearest 1500. Don't ask...
        private const int MINUTES_PER_WEEK = MINUTES_PER_DAY * 7;
        private const string FILENAME = "schedule"; //Path to the schedule file
        
        private MinuteState[] _array;

        public frmMain()
        {
            _array = new MinuteState[MINUTES_PER_WEEK];
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSlotDialog addDialog = new frmSlotDialog(0, 0, new MinuteState('\0'));
            addDialog.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSlotDialog editDialog = new frmSlotDialog(0, 0, new MinuteState('\0'));
            editDialog.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            loadArray();
            _array[0] = new MinuteState(Convert.ToChar(1));
            _array[7] = new MinuteState(Convert.ToChar(0));
            _array[14] = new MinuteState(Convert.ToChar(0));
            _array[21] = new MinuteState(Convert.ToChar(1));
            _array[28] = new MinuteState(Convert.ToChar(1));
            _array[35] = new MinuteState(Convert.ToChar(1));
            _array[42] = new MinuteState(Convert.ToChar(2));
            _array[49] = new MinuteState(Convert.ToChar(2));
            _array[56] = new MinuteState(Convert.ToChar(1));
            _array[63] = new MinuteState(Convert.ToChar(1));
            _array[70] = new MinuteState(Convert.ToChar(0));
            _array[77] = new MinuteState(Convert.ToChar(0));
            _array[84] = new MinuteState(Convert.ToChar(3));
            _array[91] = new MinuteState(Convert.ToChar(0));
            parseArray();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loadArray();
            _array[0] = new MinuteState(Convert.ToChar(1));
            _array[7] = new MinuteState(Convert.ToChar(0));
            _array[14] = new MinuteState(Convert.ToChar(0));
            _array[21] = new MinuteState(Convert.ToChar(1));
            _array[28] = new MinuteState(Convert.ToChar(1));
            _array[35] = new MinuteState(Convert.ToChar(1));
            _array[42] = new MinuteState(Convert.ToChar(2));
            _array[49] = new MinuteState(Convert.ToChar(2));
            _array[56] = new MinuteState(Convert.ToChar(1));
            _array[63] = new MinuteState(Convert.ToChar(1));
            _array[70] = new MinuteState(Convert.ToChar(0));
            _array[77] = new MinuteState(Convert.ToChar(0));
            _array[84] = new MinuteState(Convert.ToChar(3));
            _array[91] = new MinuteState(Convert.ToChar(0));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadArray();
        }

        private int parseWeekday(int start)
        {
            //get first element - use this to compare to
            char first = _array[start].Value;
            
            //Iterate through all elements in this day (via i += 7)
            for (int i = start; i < MINUTES_PER_DAY; i+=7)
            {

            }

            return 0;
        }

        private void parseArray()
        {
            //for (int day = 0; day < 7; ++day)
            {
                int day = 0;
                int ind = day; //Take first index to compare 

                for (int i = 1; i < MINUTES_PER_DAY; ++i)
                {
                    //if (i < 10)
                    //    Console.WriteLine("First: " + (int)_array[7 * i + day].Value + ", Prev: " + (int)_array[(i - 1) * 7 + day].Value);
                    if (_array[7 * i + day].Value != _array[(i-1)*7+day].Value)
                    {
                        //ship off slot from ind to i*7
                        Console.WriteLine("Start: " + ind + ", Finish: " + i);
                        ind = i;
                    }
                }
            }
        }

        private void loadArray()
        {
            FileStream file = File.Open(FILENAME, FileMode.OpenOrCreate);

            if (file.Length == MINUTES_PER_WEEK) //If the file already exists
            {
                using (BinaryReader load = new BinaryReader(file))
                    for (int i = 0; i < file.Length && i < MINUTES_PER_WEEK; ++i)
                        _array[i] = new MinuteState(load.ReadChar());
            }
            else if (file.Length < MINUTES_PER_WEEK) //or if the file has just been created or its not the right size, erase
            {
                using (BinaryWriter fill = new BinaryWriter(file))
                    for (int i = 0; i < MINUTES_PER_WEEK; ++i)
                        fill.Write((_array[i] = new MinuteState('\0')).Value); //Had to squeeze this on one line, just for fun...
            }

            file.Close();
        }

        private void saveArray()
        {
            FileStream file = File.Open(FILENAME, FileMode.OpenOrCreate);

            using (BinaryWriter save = new BinaryWriter(file))
                for (int i = 0; i < MINUTES_PER_WEEK; ++i)
                    save.Write(_array[i].Value);

            file.Close();
        }
    }
}
