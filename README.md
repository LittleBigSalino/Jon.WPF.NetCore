# Jon.WPF.NetCore.Controls

A WPF .NET Core v6.0 user control library containing customizable and easy-to-use controls for your WPF applications.

![image](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/SamplesMainWindow1.png)

![image](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/SamplesMainWindow2.png)


NEW!

![image](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/WizardFirstScreen.png)

NEW!

![image](WizardFirstScreen.png)

## Controls

- ToggleSwitch Control
- Time Picker Control
- Rating Control
- Watermark TextBox Control
- Color Picker Control
- Color Palette Control
- PropertyGrid Control
- Wizard Control

## Table of Contents

- [ToggleSwitch Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/ToggleSwitch.md)
- [Time Picker Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/TimePicker.md)
- [Rating Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/RatingControl.md)
- [Watermark TextBox Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/WatermarkTextbox.md)
- [Color Picker Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/ColorPicker.md)
- [Color Palette Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/ColorPaletteControl.md)
- [PropertyGrid Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/PropertyGrid.md)
- [Wizard Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/WizardWindow.md)

## Getting Started

To use the controls in your WPF application, follow these steps:

1. Clone or download the source code from GitHub and add the user control library project to your solution.

2. Add a reference to the user control library in your WPF application project.

3. In the XAML file where you want to use a control, add the following namespace declaration at the top:

   ```xml
   xmlns:controls="clr-namespace:MyUserControlLibrary;assembly=MyUserControlLibrary"
   ```

4. Add the control to your XAML layout.

## Controls

### 1. ToggleSwitch

A customizable ToggleSwitch Control that provides a simple and intuitive way for users to toggle a setting on or off with customizable "on" and "off" text labels.

Refer to the ToggleSwitch Control Specification for more details, including properties, events, and customization options.

### 2. TimePicker

The Time Picker control allows users to select a specific time value within a given range. It supports 12-hour and 24-hour clock formats, and offers an intuitive and easy-to-use interface.

Refer to the Time Picker Control Specification for more details, including properties, data binding, validation, and customization options.

### 3. RatingControl

A customizable Rating Control that allows users to provide a rating using stars or other symbols. The control supports different rating levels, custom symbols, and half-star ratings.

Refer to the Rating Control Specification for more details, including properties, data binding, and customization options.

### 4. WatermarkTextBox

A TextBox control with a watermark feature, allowing you to display a placeholder text when the TextBox is empty. This helps users understand the purpose of the input field.

Refer to the WatermarkTextBox Control Specification for more details, including properties, events, and customization options.

### 5. ColorPicker

A ColorPicker control that allows users to choose a color from a color palette or define custom colors using RGB, HSL, or HEX values. This control provides an intuitive user interface for selecting colors.

Refer to the ColorPicker Control Specification for more details, including properties, data binding, and customization options.

### 6. Color Palette Control

A versatile Color Palette Control that enables users to pick colors from a user-defined color spectrum. The palette can be easily customized by adjusting its block dimensions and wrapping behavior, and it also provides a `SelectedColor` property to access the chosen color.

Refer to the [Color Palette Control Specification](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/ColorPaletteControl.md) for more details, including properties, data binding, and customization options.

### 7. PropertyGrid Control

A PropertyGrid user control for displaying and editing object properties in a user-friendly way. It provides auto-generation features, customizable editors, and support for property decorators.

Refer to the PropertyGrid Control Specification for more details, including properties, data binding, and customization options.

### 8. Wizard Control
A versatile and customizable wizard control to create step-by-step user interfaces in WPF applications. The Most Wanted WPF Wizard control supports various built-in views and allows you to create custom views by implementing the StepBase interface on a UserControl.
![image](WizardFirstScreen.png)

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Support

If you encounter any issues or have questions, please feel free to open an issue on GitHub. Contributions are welcome!
