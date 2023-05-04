# ToggleSwitch Control for WPF

A customizable ToggleSwitch Control for WPF applications built on the .NET Core v6.0 framework. This control provides a simple and intuitive way for users to toggle a setting on or off with customizable "on" and "off" text labels.

![ToggleSwitch Control](ToggleSwitchControlScreenshot.png)

## Features

- Customizable "on" and "off" text labels
- Visual indication of the current setting state (on/off)
- Simple and intuitive user interface
- Built-in event handling for setting change events

## Getting Started

To use the ToggleSwitch Control in your WPF application, follow these steps:

### 1. Add the ToggleSwitch Control to your project

Clone or download the source code from GitHub and add the ToggleSwitch Control to your project.

### 2. Add the namespace declaration

In the XAML file where you want to use the control, add the following namespace declaration to the top:

```xaml
xmlns:controls="clr-namespace:YourNamespace.Controls;assembly=YourAssemblyName"
```

Replace `YourNamespace` with the actual namespace of the ToggleSwitch Control in your project and `YourAssemblyName` with the actual name of your assembly.

### 3. Use the ToggleSwitch Control in your XAML

Add the ToggleSwitch Control to your XAML layout:

```xaml
<controls:ToggleSwitch x:Name="MyToggleSwitch" OnText="Enabled" OffText="Disabled" />
```

### 4. Handle setting change events

To handle setting change events, add an event handler in the code-behind:

```csharp
public MainWindow()
{
    InitializeComponent();

    MyToggleSwitch.IsOnChanged += MyToggleSwitch_IsOnChanged;
}

private void MyToggleSwitch_IsOnChanged(object sender, DependencyPropertyChangedEventArgs e)
{
    // Handle the IsOnChanged event here.
    // You can use MyToggleSwitch.IsOn to get the current state of the ToggleSwitch.
}
```

## Properties

The ToggleSwitch Control has the following dependency properties:

- `OnText` (string): The text to display when the control is in the "on" position. Default value: "On".
- `OffText` (string): The text to display when the control is in the "off" position. Default value: "Off".
- `IsOn` (bool): The current state of the control. Default value: `false`.

## Events

The ToggleSwitch Control has one built-in event: `IsOnChanged`. This event is fired whenever the `IsOn` property is changed.

## Customization

### Customize the "on" and "off" text labels

To customize the "on" and "off" text labels, set the `OnText` and `OffText` properties in XAML:

```xaml
<controls:ToggleSwitch x:Name="MyToggleSwitch" OnText="Active" OffText="Inactive" />
```

### Customize the appearance

You can customize the appearance of the ToggleSwitch Control by modifying the XAML template in the `ToggleSwitchControl.xaml` file. For example, you can change the background color, text color, and corner radius.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
## Examples

### Example 1: Basic usage

Add the ToggleSwitch Control to your XAML layout with default "On" and "Off" text labels:

```xaml
<controls:ToggleSwitch x:Name="MyToggleSwitch" />
```

### Example 2: Custom text labels

Add the ToggleSwitch Control to your XAML layout with custom "On" and "Off" text labels:

```xaml
<controls:ToggleSwitch x:Name="MyToggleSwitch" OnText="Enabled" OffText="Disabled" />
```

### Example 3: Data binding

Bind the `IsOn` property of the ToggleSwitch Control to a property in your ViewModel:

```xaml
<controls:ToggleSwitch x:Name="MyToggleSwitch" IsOn="{Binding MyBooleanProperty, Mode=TwoWay}" />
```

## Contributing

If you'd like to contribute to the development of the ToggleSwitch Control, please follow these guidelines:

1. Fork the repository on GitHub.
2. Create a branch for your changes.
3. Make your changes and commit them to your branch.
4. Create a pull request with a description of your changes.

All contributions are greatly appreciated!

## Support

If you encounter any issues or have questions about the ToggleSwitch Control, please create an issue on the GitHub repository, and we will do our best to help you.

## Credits

ToggleSwitch Control was developed by [Your Name](mailto:youremail@example.com) as an open-source project. Special thanks to all contributors and users of the control.

---

Happy coding!