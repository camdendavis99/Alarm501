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
        /// <summary>
        /// List of alarms added by user
        /// </summary>
        public BindingList<Alarm> AlarmList = new BindingList<Alarm>();

        /// <summary>
        /// List of timers of alarms; used to avoid garbage collection
        /// </summary>
        public List<System.Threading.Timer> TimerList = new List<System.Threading.Timer>();

        /// <summary>
        /// Contructor - creates a new UI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            ReadSavedAlarms();
            uxAlarmList.DataSource = AlarmList;
        }

        /// <summary>
        /// Saves current alarms to a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Reads saved alarms from text file
        /// </summary>
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
                    AddAlarm(alarm);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (FileNotFoundException) { }
        }

        /// <summary>
        /// Adds a new alarm and timer from user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddButton_Click(object sender, EventArgs e)
        {
            AddOrEditAlarmDialog addAlarmDialog = new AddOrEditAlarmDialog();
            if (addAlarmDialog.ShowDialog() == DialogResult.OK)
            {
                Alarm alarm = new Alarm(addAlarmDialog.Time, addAlarmDialog.On);
                AddAlarm(alarm);
            }
        }

        /// <summary>
        /// Adds a given alarm to the alarm list and creates a timer for it
        /// </summary>
        /// <param name="alarm"></param>
        private void AddAlarm(Alarm alarm)
        {
            AlarmList.Add(alarm);

            uxEditButton.Enabled = true;
            if (AlarmList.Count == 10)
            {
                uxAddButton.Enabled = false;
            }

            TimeSpan timeRemaining = GetTimeRemaining(alarm);
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);

            var newTimer = new System.Threading.Timer(TriggerAlarm, alarm, timeRemaining, oneDay); ;
            TimerList.Add(newTimer);
        }

        private void MonitorAlarm(Alarm alarm)
        {
            Thread.Sleep(alarm.AlertTime.Seconds);
            TriggerAlarm(alarm);
        }

        /// <summary>
        /// Gets time from now until given alarm's time
        /// </summary>
        /// <param name="alarm">alarm to check time until</param>
        /// <returns>Time remaining as a TimeSpan</returns>
        private TimeSpan GetTimeRemaining(Alarm alarm)
        {
            DateTime alarmTime = DateTime.Today.Add(alarm.AlertTime);
            if (DateTime.Now.CompareTo(alarmTime) >= 1)
            {
                return DateTime.Today.AddDays(1).Add(alarm.AlertTime) - DateTime.Now;
            }
            return alarmTime - DateTime.Now;
        }                                   
                                 
        /// <summary>
        /// Triggers the given alarm
        /// </summary>
        /// <param name="o"></param>
        private void TriggerAlarm(object o)
        {
            Alarm alarm = (Alarm)o;
            if (alarm.IsOn)
            {
                alarm.Trigger();
                this.Invoke(new Action(() => { UpdateSnoozeStopButtons(); }));
            }
        }

        private void UpdateSnoozeStopButtons()
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            uxAlarmList.DataSource = AlarmList;
            if (alarm.Status == AlarmStatus.Triggered)
            {
                uxSnoozeButton.Enabled = true;
                uxStopButton.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for selecting a different alarm in the ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            if (alarm != null)
            {
                uxSnoozeButton.Enabled = alarm.Status == AlarmStatus.Triggered;
                uxStopButton.Enabled = alarm.Status == AlarmStatus.Triggered;
            }
        }

        /// <summary>
        /// Event handler for editing an alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            AddOrEditAlarmDialog addAlarmDialog = new AddOrEditAlarmDialog();

            if (addAlarmDialog.ShowDialog() == DialogResult.OK)
            {
                alarm.Edit(addAlarmDialog.Time, addAlarmDialog.On);
            }
        }

        /// <summary>
        /// Event handler for snoozing an alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnoozeButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            alarm.Snooze();
            uxSnoozeButton.Enabled = false;
            uxStopButton.Enabled = false;

            TimeSpan timeRemaining = GetTimeRemaining(alarm);
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);

            var newTimer = new System.Threading.Timer(TriggerAlarm, alarm, timeRemaining, oneDay); ;
            TimerList.Add(newTimer);
        }

        /// <summary>
        /// Event handler for stopping an alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStopButton_Click(object sender, EventArgs e)
        {
            Alarm alarm = (Alarm)uxAlarmList.SelectedItem;
            alarm.Stop();
            uxSnoozeButton.Enabled = false;
            uxStopButton.Enabled = false;
        }
    }
}
