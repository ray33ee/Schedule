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
        private const string FILENAME = "schedule.bin"; //Path to the schedule file
        
        private State[] _array;

        public frmMain()
        {
            _array = new State[MINUTES_PER_WEEK];
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadArray();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create dialog object and display modal dialog
            frmSlotDialog addDialog = new frmSlotDialog();
            addDialog.ShowDialog();

            if (addDialog.DialogResult == DialogResult.OK)
                addSlot(addDialog.Slot);

            parseArray();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = lstSlots.SelectedIndex;

            if (index == -1)
                return;

            Slot selectedSlot = (Slot)lstSlots.SelectedItem;

            frmSlotDialog editDialog = new frmSlotDialog(new Slot((Slot)lstSlots.SelectedItem));
            editDialog.ShowDialog();


            if (editDialog.DialogResult == DialogResult.OK)
            {
                deleteSlot(selectedSlot);
                addSlot(editDialog.Slot);
            }

            parseArray();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstSlots.SelectedIndex;

            if (index == -1)
                return;

            deleteSlot((Slot)lstSlots.SelectedItem);
            parseArray();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveArray();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadArray();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lstSlots.SelectedIndex == -1)
                return;

            //Create dialog object and display modal dialog
            frmSlotDialog cpyDialog = new frmSlotDialog((Slot)lstSlots.SelectedItem);
            cpyDialog.ShowDialog();

            if (cpyDialog.DialogResult == DialogResult.OK)
                addSlot(cpyDialog.Slot);

            parseArray();
        }

        private void addSlot(Slot add)
        {
            for (int i = add.Start.IntTime; i < add.Finish.IntTime; ++i)
                _array[7 * i + add.Day].Value = (char)(_array[7 * i + add.Day].Value | add.State.Value);
        }

        private void deleteSlot(Slot del)
        {
            Console.WriteLine("Delete index: " + lstSlots.SelectedIndex);

            //Erase slot in array
            for (int i = del.Start.IntTime; i < del.Finish.IntTime; ++i)
                _array[7 * i + del.Day].Value = (char)0;
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
                        State found = _array[7 * ind + day];
                        if (found.Value != 0)
                            lstSlots.Items.Add(new Slot(day, new Time(ind), new Time(i), found));
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
                        _array[i] = new State(load.ReadChar());
            }
            else if (file.Length < MINUTES_PER_WEEK) //or if the file has just been created or its not the right size, erase
            {
                using (BinaryWriter fill = new BinaryWriter(file))
                    for (int i = 0; i < MINUTES_PER_WEEK; ++i)
                        fill.Write((_array[i] = new State()).Value); //Had to squeeze this on one line, just for fun. Should probably be _array[i] = new MinuteState('\0'); fill.Write(_array[i].Value);
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
