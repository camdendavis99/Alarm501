using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Alarm501
{
    /// <summary>
    /// Possible states of an alarm
    /// </summary>
    public enum AlarmStatus
    {
        Off,
        On,
        Triggered,
        Stopped
    }

    /// <summary>
    /// Represents an alarm
    /// </summary>
    public class Alarm : INotifyPropertyChanged
    {
        /// <summary>
        /// Amount of time to push back alarm when snoozed
        /// </summary>
        private static TimeSpan SNOOZE_TIME = new TimeSpan(0, 0, 30);

        /// <summary>
        /// Event handler for property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Helper function to invoke propert changed event handler
        /// </summary>
        /// <param name="property"></param>
        private void NotifyOfPropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Normal time of alarm
        /// </summary>
        public TimeSpan Time { get; private set; }
        
        /// <summary>
        /// Time that alarm will go off accounting for snoozes
        /// </summary>
        public TimeSpan AlertTime { get; private set; }

        /// <summary>
        /// Whether or not the alarm is on
        /// </summary>
        public bool IsOn => Status != AlarmStatus.Off;

        private AlarmStatus status;

        public AlarmStatus Status
        {
            get => status;
            private set
            {
                status = value;
                NotifyOfPropertyChange("Status");
            }
        }

        /// <summary>
        /// Constructor - creates a new alarm
        /// </summary>
        /// <param name="time">time of the alarm</param>
        /// <param name="on">whether or not the alarm is on</param>
        public Alarm(DateTime time, bool on)
        {
            long ticks = time.TimeOfDay.Ticks;
            Time = new TimeSpan(ticks - (ticks % 10000000));
            AlertTime = Time;
            Status = on ? AlarmStatus.On : AlarmStatus.Off;
        }

        /// <summary>
        /// String representation of alarm
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Time.Hours <= 12)
                return $"{Time} AM\t{Status}";

            TimeSpan twelveHours = new TimeSpan(12, 0, 0);
            return $"{Time - twelveHours} PM\t{Status}";
        }

        /// <summary>
        /// Triggers the alarm so it can be stopped or snoozed
        /// </summary>
        public void Trigger()
        {
            Status = AlarmStatus.Triggered;
            NotifyOfPropertyChange("Status");
        }

        /// <summary>
        /// Snoozes the alarm; pushes back time of 
        /// </summary>
        public void Snooze()
        {
            Status = AlarmStatus.On;
            AlertTime = DateTime.Now.Add(SNOOZE_TIME).TimeOfDay;
        }

        /// <summary>
        /// Stops the alarm
        /// </summary>
        public void Stop()
        {
            Status = AlarmStatus.Stopped;
            AlertTime = Time;
        }

        /// <summary>
        /// Edits the time of the alarm, and whether or not it is on
        /// </summary>
        /// <param name="time">time the alarm will be set to</param>
        /// <param name="on">whether or not the alarm will be on.
        /// </param>
        public void Edit(DateTime time, bool on)
        {
            Time = time.TimeOfDay;
            AlertTime = Time;
            Status = AlarmStatus.On;
            NotifyOfPropertyChange("Time");
        }
    }
}
