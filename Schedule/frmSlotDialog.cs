using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class frmSlotDialog : Form
    {
        private Slot _slot;

        public Slot Slot { get => _slot; }

        public frmSlotDialog() : this(new Slot())
        {
            
        }

        public frmSlotDialog(Slot slot) 
        {
            _slot = slot;
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
            tmeStart.Value = zero.AddHours(Slot.Start.Hour).AddMinutes(Slot.Start.Minute);
            tmeFinish.Value = zero.AddHours(Slot.Finish.Hour).AddMinutes(Slot.Finish.Minute);

            //Initialise combo box with start values
            cbxHW.Checked = Slot.State.HW;
            cbxCH.Checked = Slot.State.CH;
            cbxWF.Checked = Slot.State.WF;
            cbxIH.Checked = Slot.State.IH;

            cboWeekday.SelectedIndex = Slot.Day;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Make sure entries are valid
            Time start =  new Time(tmeStart.Value.TimeOfDay.Hours, tmeStart.Value.TimeOfDay.Minutes);
            Time finish = new Time(tmeFinish.Value.TimeOfDay.Hours, tmeFinish.Value.TimeOfDay.Minutes);
            
            if (finish.IntTime <= start.IntTime)
            { 
                MessageBox.Show("Invalid Slot - Start time must be before finish time.", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboWeekday.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid Slot - Invalid weekday.", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboWeekday.Text == "")
            {
                MessageBox.Show("Invalid Slot - Invalid weekday.", "Invalid Slot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Copy valid entries
            _slot.Day = cboWeekday.SelectedIndex;

            _slot.Start = start;
            _slot.Finish = finish;

            _slot.State = new State(Convert.ToInt32(cbxHW.Checked), Convert.ToInt32(cbxCH.Checked), Convert.ToInt32(cbxWF.Checked), Convert.ToInt32(cbxIH.Checked));

            //Dialog OK
            DialogResult = DialogResult.OK;
        }
    }
}
