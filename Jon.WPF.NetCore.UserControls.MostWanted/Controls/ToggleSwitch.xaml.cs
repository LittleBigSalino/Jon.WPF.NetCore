﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    /// <summary>
    /// Interaction logic for ToggleSwitch.xaml
    /// </summary>
    public partial class ToggleSwitch : UserControl
    {
        public string OnText
        {
            get { return (string)GetValue(OnTextProperty); }
            set { SetValue(OnTextProperty, value); }
        }
        public string OffText
        {
            get { return (string)GetValue(OffTextProperty); }
            set { SetValue(OffTextProperty, value); }
        }
        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }
        public ToggleSwitch()
        {
            InitializeComponent();
            UpdateVisualState();
        }

        public static readonly DependencyProperty OnTextProperty = DependencyProperty.Register(
            nameof(OnText), typeof(string), typeof(ToggleSwitch), new PropertyMetadata("On"));
        public static readonly DependencyProperty OffTextProperty = DependencyProperty.Register(
            nameof(OffText), typeof(string), typeof(ToggleSwitch), new PropertyMetadata("Off"));
        public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register(
            nameof(IsOn), typeof(bool), typeof(ToggleSwitch), new PropertyMetadata(false, OnIsOnPropertyChanged));
        public event DependencyPropertyChangedEventHandler? IsOnChanged;
        private static void OnIsOnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is ToggleSwitch toggleSwitchControl)
            {
                toggleSwitchControl.UpdateVisualState();
                toggleSwitchControl.IsOnChanged?.Invoke(sender, e);
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            IsOn = true;
            UpdateVisualState();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            IsOn = false;
            UpdateVisualState();
        }
        private void UpdateVisualState()
        {
            if (IsOn)
            {
                OnTextBlock.Opacity = 1;
                OffTextBlock.Opacity = 0.2;
            }
            else
            {
                OnTextBlock.Opacity = 0.2;
                OffTextBlock.Opacity = 1;
            }
        }
    }

    public class SwitchForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is ToggleSwitch toggleSwitch && values[1] is bool isOn)
            {
                if (toggleSwitch.Name == "OnTextBlock")
                {
                    return isOn ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    return isOn ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Black);
                }
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}