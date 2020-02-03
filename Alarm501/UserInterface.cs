using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.ObjectModel;
using System.IO;

namespace Alarm501
{
    public partial class UserInterface : Form
    {
        public BindingList<Alarm> AlarmList = new BindingList<Alarm>();

        public List<System.Threading.Timer> TimerList = new List<System.Threading.Timer>();

        public event System.ComponentModel.ListChangedEventHandler ListChanged;

        public UserInterface()
        {
            InitializeComponent();
            ReadSavedAlarms();
            uxAlarmList.DataSource = AlarmList;
            AlarmList.ListChanged += OnListChanged;
        }

        public delegate void ListChangedEventHandler(object sender, ListChangedEventArgs e);
        
        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            if (alarm.Status == AlarmStatus.Triggered)
            {
                uxSnoozeButton.Enabled = true;
                uxStopButton.Enabled = true;
            }
        }

        private void SaveAlarms(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("SavedAlarms.txt");
            foreach (Alarm alarm in AlarmList)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(alarm.ToString().Split('\t')[0]);
                sb.Append(';');
                if (alarm.IsOn)
                    sb.Append("On");
                else
                    sb.Append("Off");
                sw.WriteLine(sb.ToString());
            }
            sw.Close();
        }

        private void ReadSavedAlarms()
        {
            try
            {
                StreamReader sr = new StreamReader("SavedAlarms.txt");
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] split = line.Split(';');
                    DateTime time = DateTime.Parse(split[0]);
                    bool on = split[1].Equals("On");
                    Alarm alarm = new Alarm(time, on);
                    AlarmList.Add(alarm);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (FileNotFoundException) { }
        }

        private void uxAddButton_Click(object sender, EventArgs e)
        {
            AddOrEditAlarmDialog addAlarmDialog = new AddOrEditAlarmDialog();
            if (addAlarmDialog.ShowDialog() == DialogResult.OK)
            {
                Alarm alarm = new Alarm(addAlarmDialog.Time, addAlarmDialog.On);
                AlarmList.Add(alarm);
                
                uxEditButton.Enabled = true;
                if (AlarmList.Count == 10)
                {
                    uxAddButton.Enabled = false;
                }

                TimeSpan timeRemaining = GetTimeRemaining(alarm);
                TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
                var newTimer = new System.Threading.Timer(TriggerAlarm, alarm, timeRemaining, oneDay);
                TimerList.Add(newTimer);
            }
        }

        private TimeSpan GetTimeRemaining(Alarm alarm)
        {
            DateTime alarmTime = DateTime.Today.Add(alarm.AlertTime);
            if (DateTime.Now.CompareTo(alarmTime) >= 1)
            {
                return DateTime.Today.AddDays(1).Add(alarm.AlertTime) - DateTime.Now;
            }
            return alarmTime - DateTime.Now;
        }                                   
                                            
        private void TriggerAlarm(object o)
        {
            Alarm alarm = (Alarm)o;
            if (alarm.IsOn)
            {
                alarm.Trigger();
                
            }
        }

        private void uxAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            uxSnoozeButton.Enabled = alarm.Status == AlarmStatus.Triggered;
            uxStopButton.Enabled = alarm.Status == AlarmStatus.Triggered;
        }

        private void uxEditButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            AddOrEditAlarmDialog addAlarmDialog = new AddOrEditAlarmDialog();

            if (addAlarmDialog.ShowDialog() == DialogResult.OK)
            {
                alarm.Edit(addAlarmDialog.Time, addAlarmDialog.On);
            }
        }

        private void SnoozeButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            alarm.Snooze();
            uxSnoozeButton.Enabled = false;
            uxStopButton.Enabled = false;
        }

        private void uxStopButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            alarm.Stop();
            uxSnoozeButton.Enabled = false;
            uxStopButton.Enabled = false;
        }
    }
}
