

# Product Build Specification: ToggleSwitch Control

## Overview

The ToggleSwitch Control is a custom user control for use in C# WPF applications built on the .NET Core v6.0 framework. It provides a simple way for users to toggle a setting on or off, with customizable "on" and "off" text labels.

## Features

- Customizable "on" and "off" text labels
- Visual indication of current setting state (on/off)
- Simple and intuitive user interface
- Built-in event handling for setting change events

## Dependencies

- .NET Core v6.0 framework
- C# programming language
- WPF user interface framework

## User Interface

The ToggleSwitch Control is a rectangular control with rounded edges, containing two text labels: one for "on" and one for "off". The control is designed to be toggled by clicking on it or by dragging it to either the "on" or "off" position.

When the control is in the "on" position, the "on" text label will be highlighted and the "off" text label will be dimmed. When the control is in the "off" position, the opposite will occur.

## Properties

The ToggleSwitch Control has the following dependency properties:

- `OnText` (string): The text to display when the control is in the "on" position. Default value: "On".
- `OffText` (string): The text to display when the control is in the "off" position. Default value: "Off".
- `IsOn` (bool): The current state of the control. Default value: `false`.

## Events

The ToggleSwitch Control has one built-in event: `IsOnChanged`. This event is fired whenever the `IsOn` property is changed.

## Code Structure

The ToggleSwitch Control is implemented as a custom user control in C# using the WPF framework. The control consists of a `ToggleButton` control and two `TextBlock` controls for the "on" and "off" labels.

The control's appearance and behavior are defined in XAML, while the event handling and property management are handled in C# code-behind.

## XAML

```xaml
<UserControl x:Class="ToggleSwitchControl.ToggleSwitchControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d" 
             d:DesignHeight="30" d:DesignWidth="60">
    <Grid>
        <ToggleButton x:Name="ToggleButton" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" 
                      Background="{Binding RelativeSource={RelativeSource AncestorType=UserControl}, Path=Background}" 
                      IsChecked="{Binding RelativeSource={RelativeSource AncestorType=UserControl}, Path=IsOn}" 
                      ClickMode="Press"/>
        <TextBlock x:Name="OnTextBlock" Text="{Binding RelativeSource={RelativeSource AncestorType=UserControl}, Path=OnText}" 
                   HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="White" Opacity="0.5" />
        <TextBlock x:Name="OffTextBlock" Text="{Binding RelativeSource={RelativeSource AncestorType=UserControl}, Path=OffText}" 
                   HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="White" Opacity="0.5"/>
    </Grid>
</UserControl>
```

## C#

```csharp```csharp
using System.Windows;
using System.Windows.Controls;

namespace ToggleSwitchControl
{
    public partial class ToggleSwitchControl : UserControl
    {
        public ToggleSwitchControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty OnTextProperty = DependencyProperty.Register(
            nameof(OnText), typeof(string), typeof(ToggleSwitchControl), new PropertyMetadata("On"));

        public string OnText
        {
            get { return (string)GetValue(OnTextProperty); }
            set { SetValue(OnTextProperty, value); }
        }

        public static readonly DependencyProperty OffTextProperty = DependencyProperty.Register(
            nameof(OffText), typeof(string), typeof(ToggleSwitchControl), new PropertyMetadata("Off"));

        public string OffText
        {
            get { return (string)GetValue(OffTextProperty); }
            set { SetValue(OffTextProperty, value); }
        }

        public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register(
            nameof(IsOn), typeof(bool), typeof(ToggleSwitchControl), new PropertyMetadata(false, OnIsOnPropertyChanged));

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        private static void OnIsOnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var toggleSwitchControl = sender as ToggleSwitchControl;
            if (toggleSwitchControl != null)
            {
                toggleSwitchControl.UpdateVisualState();
                toggleSwitchControl.IsOnChanged?.Invoke(sender, e);
            }
        }

        public event DependencyPropertyChangedEventHandler IsOnChanged;

        private void UpdateVisualState()
        {
            if (IsOn)
            {
                OnTextBlock.Opacity = 1;
                OffTextBlock.Opacity = 0.5;
            }
            else
            {
                OnTextBlock.Opacity = 0.5;
                OffTextBlock.Opacity = 1;
            }
        }
    }
}
```

## Conclusion

The ToggleSwitch Control is a simple and intuitive way for users to toggle a setting on or off in WPF applications. With customizable text labels and built-in event handling, this user control is a great addition to any project.