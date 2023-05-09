# WatermarkTextBox Control for WPF

The WatermarkTextBox control is a custom user control for C# WPF .NET Core v6.0 that displays a watermark until the user starts typing. The control is often used for providing hints or default values for input fields. It offers a user-friendly and visually appealing way to interact with text inputs in your application.

![WatermarkTextBox Control](WatermarkTextbox.png)

## Features

- Display a watermark text when the TextBox is empty
- Remove the watermark when the TextBox receives focus or the user starts typing
- Reapply the watermark if the TextBox loses focus and is still empty
- Allow customization of the watermark text and color
- Allow customization of the foreground and background colors of the TextBox
- Implement data binding for the TextBox value

## Getting Started

To use the WatermarkTextBox Control in your WPF application, follow these steps:

### 1. Add the WatermarkTextBox Control to your project

Clone or download the source code from GitHub and add the WatermarkTextBox.xaml and WatermarkTextBox.xaml.cs files to your project.

### 2. Add the namespace declaration

In the XAML file where you want to use the control, add the following namespace declaration at the top:

```xaml
xmlns:controls="clr-namespace:YourNamespace.Controls;assembly=YourAssemblyName"
```

Replace `YourNamespace` with the actual namespace of the WatermarkTextBox Control in your project and `YourAssemblyName` with the actual name of your assembly.

### 3. Use the WatermarkTextBox Control in your XAML

Add the WatermarkTextBox Control to your XAML layout:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your text here" />
```

### 4. Data Binding (optional)

Bind the `Text` property of the WatermarkTextBox Control to a property in your ViewModel:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your text here" Text="{Binding MyTextProperty, Mode=TwoWay}" />
```

## Properties

The WatermarkTextBox Control has the following dependency properties:

- `Watermark` (string): The text to display as the watermark when the TextBox is empty. Default value: "Watermark".
- `WatermarkColor` (Brush): The color of the watermark text. Default value: LightGray.
- `Text` (string): The text content of the TextBox. Default value: "".

## Customization

### Customize the Watermark Text and Color

To customize the watermark text and color, set the `Watermark` and `WatermarkColor` properties in XAML:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your email" WatermarkColor="Red" />
```

### Customize the TextBox Appearance

You can customize the appearance of the WatermarkTextBox Control by modifying the XAML template in the `WatermarkTextBox.xaml` file. For example, you can change the foreground color, background color, and border style of the TextBox.

## Examples

### Example 1: Basic Usage

Add the WatermarkTextBox Control to your XAML layout with default watermark text:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" />
```

### Example 2: Custom Watermark Text

Add the WatermarkTextBox Control to your XAML layout with custom watermark text:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your email" />
```

### Example 3: Custom Watermark Text and Color

Add the WatermarkTextBox
Add the WatermarkTextBox Control to your XAML layout with custom watermark text and color:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your email" WatermarkColor="Red" />
```

### Example 4: Data Binding

Bind the `Text` property of the WatermarkTextBox Control to a property in your ViewModel:

```xaml
<controls:WatermarkTextBox x:Name="MyWatermarkTextBox" Watermark="Enter your email" Text="{Binding MyEmailProperty, Mode=TwoWay}" />
```

## Contributing

If you'd like to contribute to the development of the WatermarkTextBox Control, please follow these guidelines:

1. Fork the repository on GitHub.
2. Create a branch for your changes.
3. Make your changes and commit them to your branch.
4. Create a pull request with a description of your changes.

All contributions are greatly appreciated!

## Support

If you encounter any issues or have questions about the WatermarkTextBox Control, please create an issue on the GitHub repository, and we will do our best to help you.

## Credits

WatermarkTextBox Control was developed by [Jon M. Sales](mailto:jonsales@jonmsales.com) as an open-source project. Special thanks to all contributors and users of the control.

---

Happy coding!