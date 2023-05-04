Sure, here's a suggested markdown format for the user control:

## RatingControl

The `RatingControl` is a user control in WPF that allows users to rate items on a scale of 1 to 5 stars.

### Features

- Users can click on one of five stars to indicate their rating
- The control can display both a read-only and an editable mode
- The control can display half-stars to allow for more precise ratings
- The control exposes a `RatingValue` property that can be bound to a ViewModel

### Usage

To use the `RatingControl`, simply add it to your XAML as follows:

```xml
<Window x:Class="MyApp.MainWindow"
        xmlns:uc="clr-namespace:Jon.WPF.NetCore.UserControls.MostWanted.Controls;assembly=Jon.WPF.NetCore.UserControls.MostWanted"
        ...>
    <Grid>
        <uc:RatingControl RatingValue="{Binding MyRating}" />
    </Grid>
</Window>
```

In the example above, `MyRating` is a property in your ViewModel that you can bind to the `RatingValue` property of the control.

### Customization

You can customize the appearance of the `RatingControl` by changing the following resources:

- `RatingStarStyle`: the style of the star shape
- `RatingThumbStyle`: the style of the thumb (the white circle that indicates the selected rating)
- `RatingSelectedBackgroundBrush`: the background color of the selected stars
- `RatingDisabledBackgroundBrush`: the background color of the disabled stars
- `RatingDisabledBorderBrush`: the border color of the disabled stars

### Credits

This `RatingControl` was created by Jon on behalf of Most Wanted Inc.