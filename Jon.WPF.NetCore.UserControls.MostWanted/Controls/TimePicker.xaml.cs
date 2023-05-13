using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl, INotifyPropertyChanged
    {
        public DateTime? SelectedTime
        {
            get => (DateTime?)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }
        public DateTime? MinimumTime
        {
            get => (DateTime?)GetValue(MinimumTimeProperty);
            set => SetValue(MinimumTimeProperty, value);
        }
        public DateTime? MaximumTime
        {
            get => (DateTime?)GetValue(MaximumTimeProperty);
            set => SetValue(MaximumTimeProperty, value);
        }
        public bool Is24HourFormat
        {
            get => (bool)GetValue(Is24HourFormatProperty);
            set => SetValue(Is24HourFormatProperty, value);
        }
        public List<string>? AmPmOptions
        {
            get => _amPmOptions;
        }
        public int AmPmIndex
        {
            get => _amPmIndex;
            set
            {
                _amPmIndex = value;
                OnPropertyChanged();

                UpdateSelectedTime();
            }
        }
        public List<string>? Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }
        public List<string>? Minutes
        {
            get => _minutes;

            set
            {
                _minutes = value;
                OnPropertyChanged();
            }
        }
        public int HourIndex
        {
            get => _hourIndex;
            set
            {
                _hourIndex = value;
                OnPropertyChanged();

                UpdateSelectedTime();
            }
        }
        public int MinuteIndex
        {
            get => _minuteIndex;
            set
            {
                _minuteIndex = value;
                OnPropertyChanged();

                UpdateSelectedTime();
            }
        }
        static TimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
        }
        public TimePicker()
        {
            InitializeComponent();

            DataContext = this;

            Hours = GenerateHours();
            Minutes = GenerateMinutes();
        }
        private List<string> _amPmOptions = new() { "AM", "PM" };
        private int _amPmIndex;
        private List<string>? _hours;
        private List<string>? _minutes;
        private int _hourIndex;
        private int _minuteIndex;
        public static readonly DependencyProperty SelectedTimeProperty = DependencyProperty.Register(
            nameof(SelectedTime), typeof(DateTime?), typeof(TimePicker), new PropertyMetadata(null, OnSelectedTimeChanged));
        public static readonly DependencyProperty MinimumTimeProperty = DependencyProperty.Register(
            nameof(MinimumTime), typeof(DateTime?), typeof(TimePicker), new PropertyMetadata(null));
        public static readonly DependencyProperty MaximumTimeProperty = DependencyProperty.Register(
            nameof(MaximumTime), typeof(DateTime?), typeof(TimePicker), new PropertyMetadata(null));
        public static readonly DependencyProperty Is24HourFormatProperty = DependencyProperty.Register(
            nameof(Is24HourFormat), typeof(bool), typeof(TimePicker), new PropertyMetadata(false, OnIs24HourFormatChanged));
        public event PropertyChangedEventHandler? PropertyChanged;
        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var timePicker = (TimePicker)d;
            timePicker.OnSelectedTimeChanged();
        }
        private static void OnIs24HourFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TimePicker timePicker)
            {
                timePicker.Hours = timePicker.GenerateHours(); // Add this line to update the Hours property
                timePicker.OnSelectedTimeChanged();

                // Update the visibility of the AM/PM ComboBox based on the Is24HourFormat property
                if (timePicker.GetTemplateChild("PART_AmPmComboBox") is ComboBox amPmComboBox)
                {
                    amPmComboBox.Visibility = timePicker.Is24HourFormat ? Visibility.Collapsed : Visibility.Visible;
                }
            }
        }
        private static List<string> GenerateMinutes()
        {
            var minutes = new List<string>();

            for (int i = 0; i < 60; i++)
            {
                minutes.Add(i.ToString("D2"));
            }

            return minutes;
        }
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnSelectedTimeChanged()
        {
            if (SelectedTime.HasValue)
            {
                HourIndex = Is24HourFormat ? SelectedTime.Value.Hour : (SelectedTime.Value.Hour % 12 == 0 ? 11 : SelectedTime.Value.Hour % 12 - 1);
                MinuteIndex = SelectedTime.Value.Minute;
                if (!Is24HourFormat)
                {
                    AmPmIndex = SelectedTime.Value.Hour >= 12 ? 1 : 0;
                }
            }
        }
        private List<string> GenerateHours()
        {
            var hours = new List<string>();

            if (Is24HourFormat)
            {
                for (int i = 0; i < 24; i++)
                {
                    hours.Add(i.ToString("D2"));
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    hours.Add(i.ToString("D2"));
                }
            }

            return hours;
        }
        private void UpdateSelectedTime()
        {
            if (HourIndex >= 0 && MinuteIndex >= 0)
            {
                int hour = Is24HourFormat ? HourIndex : (HourIndex + 1) % 12;
                if (!Is24HourFormat && AmPmIndex == 1) // PM
                {
                    hour += 12;
                }
                int minute = MinuteIndex;
                SelectedTime = new DateTime(1, 1, 1, hour, minute, 0);
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_AmPmComboBox") is ComboBox amPmComboBox)
            {
                amPmComboBox.Visibility = Is24HourFormat ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
