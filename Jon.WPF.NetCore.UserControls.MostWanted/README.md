# Jon.WPF.NetCore.Controls

A WPF .NET Core v6.0 user control library containing customizable and easy-to-use controls for your WPF applications.

![image](http://jonmsales.com/examplePicture.png)


## Controls

- ToggleSwitch Control
- Time Picker Control
- Rating Control
- Watermark TextBox Control
- Color Picker Control

## Table of Contents

- [ToggleSwitch Control](https://github.com/LittleBigSalino/Jon.WPF.NetCore/blob/master/Jon.WPF.NetCore.UserControls.MostWanted/ToggleSwitch.md)
- [Time Picker Control](#time-picker-control-specification)
- [Rating Control](#ratingcontrol)
- [Watermark TextBox Control](#watermark-textbox-control)
- [Color Picker Control](#color-picker-user-control)

# Color Picker User Control

## Overview

The Color Picker user control is a custom control for selecting and manipulating colors. The control provides a visual interface for choosing colors and allows the user to manipulate the selected color through various means, such as sliders, color palettes, and color pickers.

## Requirements

### Functional Requirements

- The control should allow the user to select a color by clicking on a color palette.
- The control should allow the user to adjust the selected color using color sliders for Hue, Saturation, and Value (HSV).
- The control should allow the user to enter a hex code value to select a color.
- The control should allow the user to adjust the opacity of the selected color.
- The control should provide a preview of the selected color.
- The control should raise an event when the selected color changes.

### Non-Functional Requirements

- The control should be intuitive and easy to use.
- The control should be visually appealing and match the overall aesthetic of the application.
- The control should be efficient and responsive, even when dealing with large amounts of data.
- The control should be well-documented and easily extensible.

## Design

### Visual Design

The Color Picker user control should have a modern, sleek appearance that fits well with the overall design of the application. The control should be compact and unobtrusive, while still providing all of the necessary functionality.

The control should consist of the following elements:

- A color palette for selecting colors.
- Color sliders for adjusting Hue, Saturation, and Value.
- An opacity slider for adjusting the opacity of the selected color.
- A text box for entering hex code values.
- A preview area for displaying the selected color.

### Architecture

The Color Picker user control should be designed using the Model-View-ViewModel (MVVM) architectural pattern.

The control should consist of the following components:

- A View, which is responsible for displaying the control and handling user input.
- A ViewModel, which acts as an intermediary between the View and the Model.
- A Model, which contains the logic for manipulating colors and raising events.

### API

The Color Picker user control should expose the following API:

- `SelectedColor`: Gets or sets the currently selected color.
- `Opacity`: Gets or sets the opacity of the selected color.
- `ColorChanged`: An event that is raised when the selected color changes.

## Implementation

### View

The View should be implemented as a XAML file, which defines the layout and appearance of the control.

The View should consist of the following elements:

- A color palette, implemented as a Grid or UniformGrid of colored rectangles.
- Color sliders for Hue, Saturation, and Value, implemented as Slider controls.
- An opacity slider, implemented as a Slider control.
- A text box for entering hex code values, implemented as a TextBox control.
- A preview area for displaying the selected color, implemented as a Rectangle control.

### ViewModel

The ViewModel should be implemented as a C# class that contains the logic for updating the Model in response to user input and raising events when the selected color changes.

The ViewModel should provide the following functionality:

- Listen for user input on the View.
- Update the Model in response to user input.
- Raise the `ColorChanged` event when the selected color changes.

### Model

The Model should be implemented as a C# class that contains the logic for manipulating colors.

The Model should provide the following functionality:

- Convert between color formats, such as RGB and HSV.
- Calculate the resulting color when the user adjusts the color sliders.
- Calculate the resulting color when the user enters a hex code value.
- Calculate the resulting color when the user adjusts the opacity slider.
- Raise the `ColorChanged` event when the selected color changes.

### API

The API should be implemented as a set of properties and events on the ViewModel.

The ViewModel should expose the following API:

- `SelectedColor`: A property that gets or sets the currently selected color.
- `Opacity`: A property that gets or sets the opacity of the selected color.
- `ColorChanged`: An event that is raised when the selected color changes.

### Testing

The Color Picker user control should be thoroughly tested to ensure that it meets all functional and non-functional requirements.

The following types of tests should be performed:

- Unit tests, which test the individual components of the control in isolation.
- Integration tests, which test the interaction between the components of the control.
- User acceptance tests, which test the control's functionality from a user's perspective.

### Documentation

The Color Picker user control should be well-documented to facilitate ease of use and extensibility.

The following types of documentation should be provided:

- API documentation, which describes the properties and events exposed by the control.
- Code documentation, which describes the implementation of the control's components.
- User documentation, which describes how to use the control from a user's perspective.

## Conclusion

The Color Picker user control is a valuable addition to any application that requires color selection and manipulation functionality. By following the above product build specification, a high-quality and efficient control can be developed that meets all functional and non-functional requirements.
