# DualListBox User Control

A WPF .NET Core 6.0 user control that consists of two list boxes allowing the user to move items between them. Supports drag and drop functionality for ease of use.

## Features

1. Two list boxes for displaying and selecting items.
2. Buttons for moving items between the list boxes.
3. Drag and drop functionality for moving items between the list boxes.
4. Customizable appearance (styles and templates).

## Usage

### XAML

```xml
<local:DualListBox x:Name="dualListBoxControl" 
                  AvailableItemsSource="{Binding AvailableItems}" 
                  SelectedItemsSource="{Binding SelectedItems}" 
                  DisplayMemberPath="ItemName" />
```

### C#

```csharp
public class ViewModel
{
    public ObservableCollection<Item> AvailableItems { get; set; }
    public ObservableCollection<Item> SelectedItems { get; set; }
}
```

## Properties

- `AvailableItemsSource`: (Bindable) A collection that provides the source for available items in the left list box.
- `SelectedItemsSource`: (Bindable) A collection that provides the source for selected items in the right list box.
- `DisplayMemberPath`: (Optional) A string that specifies the path to a value on the source object to serve as the visual representation of the items in the list boxes.
- `SelectionMode`: (Optional) Controls the selection behavior for items in the list boxes. Default is `SelectionMode.Single`.

## Events

- `ItemsMoved`: Raised when items are moved between the list boxes. Provides information about the moved items and their source/destination.

## Customization

To apply custom styles or templates, you can use the following keys in your application's resource dictionary:

- `DualListBoxStyle`: The main style for the DualListBox control.
- `DualListBoxItemContainerStyle`: The style for the item containers in the list boxes.
- `DualListBoxButtonStyle`: The style for the buttons used to move items between the list boxes.

---

Please note that this is a high-level specification for the DualListBox user control, and it is not a fully working implementation. You will need to develop the control according to these specifications and your specific requirements.