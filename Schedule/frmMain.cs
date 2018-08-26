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
            loadArray();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //User has not selected a weekday from combo box
            if (cboWeekday.Text == "")
            {
                MessageBox.Show("Please select a weekday.", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //User has editied the combo box with an invalid week
            if (cboWeekday.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid weekday " + cboWeekday.Text + ".", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Create dialog object and display modal dialog
            frmSlotDialog addDialog = new frmSlotDialog(0, 0, new MinuteState());
            addDialog.ShowDialog();

            int day = cboWeekday.SelectedIndex;

            if (addDialog.DialogResult == DialogResult.OK)
            {
                for (int i = addDialog.Start; i < addDialog.Finish; ++i)
                    _array[7 * i + day].Value = addDialog.State.Value;
            }
            parseArray();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSlotDialog editDialog = new frmSlotDialog(0, 0, new MinuteState());
            editDialog.ShowDialog();

            parseArray();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            parseArray();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*loadArray();
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
            _array[91] = new MinuteState(Convert.ToChar(0));*/
            saveArray();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadArray();
        }

        private void parseArray()
        {
            lstSlots.Items.Clear();

            for (int day = 0; day < 7; ++day)
            {
                int ind = 0; //Take first index to compare 

                for (int i = 1; i < MINUTES_PER_DAY; ++i)
                {
                    if (_array[7 * i + day].Value != _array[(i-1)*7+day].Value)
                    {
                        lstSlots.Items.Add(new Slot(day, new Time(ind), new Time(i), _array[7 * ind + day]));
                        Console.WriteLine("Day: " + day + ", Start: " + ind + ", Finish: " + i + ", State: " + (int)_array[7*ind+day].Value);
                        ind = i;
                    }
                }
            }
        }
        private void loadArray()
        {
            FileStream file = File.Open(FILENAME, FileMode.OpenOrCreate);

            if (file.Length == MINUTES_PER_WEEK) //If the file already exists, with the correct size
            {
                using (BinaryReader load = new BinaryReader(file))
                    for (int i = 0; i < MINUTES_PER_WEEK; ++i)
                        _array[i] = new MinuteState(load.ReadChar());
            }
            else if (file.Length < MINUTES_PER_WEEK) //or if the file has just been created or its not the right size, erase
            {
                using (BinaryWriter fill = new BinaryWriter(file))
                    for (int i = 0; i < MINUTES_PER_WEEK; ++i)
                        fill.Write((_array[i] = new MinuteState()).Value); //Had to squeeze this on one line, just for fun. Should probably be _array[i] = new MinuteState('\0'); fill.Write(_array[i].Value);
            }

            file.Close();

            parseArray();
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
