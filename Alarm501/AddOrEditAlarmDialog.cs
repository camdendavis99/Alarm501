using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class AddOrEditAlarmDialog : Form
    {
        public AddOrEditAlarmDialog()
        {
            InitializeComponent();
            uxTimePicker.Value = DateTime.Now;
        }

        public DateTime Time => uxTimePicker.Value;
        public bool On => uxOnButton.Checked;
    }
}
