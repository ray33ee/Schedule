using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule01
{
    public partial class frmSlotDialog : Form
    {
        private int _start;
        private int _finish;
        private int _state;

        public int Start
        {
            get => _start;

        }

        public int Finish
        {
            get => _finish;

        }

        public int State
        {
            get => _state;

        }

        public frmSlotDialog() : this(0, 1, 0)
        {
            
        }

        public frmSlotDialog(int start_time, int finish_time, int state) 
        {
            this._start = start_time;
            this._finish = finish_time;
            this._state = state;
            InitializeComponent();
        }

        private void frmSlotDialog_Load(object sender, EventArgs e)
        {
            //Setup both DateTimePickers to be exclusively hour/minute
            tmeStart.Format = DateTimePickerFormat.Custom;
            tmeStart.CustomFormat = "HH:mm";
            tmeStart.ShowUpDown = true;

            tmeFinish.Format = DateTimePickerFormat.Custom;
            tmeFinish.CustomFormat = "HH:mm";
            tmeFinish.ShowUpDown = true;

            //Initialise pickers with start values
            DateTime zero = DateTime.Parse("0:0");
            tmeStart.Value = zero.AddHours(_start / 60).AddMinutes(_start % 60);
            tmeFinish.Value = zero.AddHours(_finish / 60).AddMinutes(_finish % 60);

            //Initialise combo box with start values
            cboState.SelectedIndex = _state;
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Make sure entries are valid
            int start = tmeStart.Value.TimeOfDay.Hours * 60 + tmeStart.Value.TimeOfDay.Minutes;
            int finish = tmeFinish.Value.TimeOfDay.Hours * 60 + tmeFinish.Value.TimeOfDay.Minutes;

            if (finish <= start)
            { 
                MessageBox.Show("Invalid Slot - Start time must be before finish time.", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboState.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid Slot - Invalid state " + cboState.Text + ".", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Copy valid entries
            _start = start;
            _finish = finish;
            _start = cboState.SelectedIndex;

            //Dialog OK
            DialogResult = DialogResult.OK;
        }
    }
}
