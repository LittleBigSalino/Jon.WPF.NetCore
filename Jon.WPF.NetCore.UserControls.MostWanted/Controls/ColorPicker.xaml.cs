using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public event EventHandler ColorChanged;


        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(ColorPicker), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnSelectedColorChanged)));



        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public ColorPicker()
        {
            InitializeComponent();            
            BindTextBoxToSlider(HueTextBox, HueSlider);
            BindTextBoxToSlider(SaturationTextBox, SaturationSlider);
            BindTextBoxToSlider(ValueTextBox, ValueSlider);
            BindTextBoxToSlider(OpacityTextBox, OpacitySlider);
            UpdateSlidersAndTextBox(SelectedColor);
        }


        private void HexCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HexCodeTextBox.Text.Length == 6)
            {
                try
                {
                    var hex = HexCodeTextBox.Text;
                    var color = (Color)ColorConverter.ConvertFromString("#" + hex);
                    SelectedColor = color;
                }
                catch
                {
                    // Handle the exception if the hex code is not valid
                }
            }
        }


        private void BindTextBoxToSlider(TextBox textBox, Slider slider)
        {
            Binding binding = new Binding("Value")
            {
                Source = slider,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                StringFormat = slider == HueSlider ? "F0" : "F2"
            };
            textBox.SetBinding(TextBox.TextProperty, binding);
        }

        private void ColorPalette_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Implement color selection from the palette
            Point clickPosition = e.GetPosition(ColorPalette);
            Color clickedColor = GetColorFromPalette(clickPosition);
            UpdateSlidersAndTextBox(clickedColor);
            SelectedColor = clickedColor;
        }

        private void HueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update SelectedColor based on the HueSlider value
            Color newColor = ColorFromHsv(e.NewValue, SaturationSlider.Value, ValueSlider.Value);
            UpdateTextBox(newColor);
            SelectedColor = newColor;
        }

        private void SaturationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update SelectedColor based on the SaturationSlider value
            Color newColor = ColorFromHsv(HueSlider.Value, e.NewValue, ValueSlider.Value);
            UpdateTextBox(newColor);
            SelectedColor = newColor;
        }

        private void ValueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update SelectedColor based on the ValueSlider value
            Color newColor = ColorFromHsv(HueSlider.Value, SaturationSlider.Value, e.NewValue);
            UpdateTextBox(newColor);
            SelectedColor = newColor;
        }


        private static void OnSelectedColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var colorPicker = (ColorPicker)sender;
            colorPicker.OnSelectedColorChanged(e);
        }


        protected virtual void OnSelectedColorChanged(DependencyPropertyChangedEventArgs e)
        {
            ColorChanged?.Invoke(this, EventArgs.Empty);
            UpdateColorPreview();
            UpdateSlidersAndTextBox(SelectedColor);
        }

        private void UpdateColorPreview()
        {
            ColorPreview.Fill = new SolidColorBrush(SelectedColor);
            AlphaPreview.Fill = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0),
                GradientStops = new GradientStopCollection
        {
            new GradientStop(Colors.Transparent, 0),
            new GradientStop(SelectedColor, 1)
        }
            };
        }


        private void UpdateSlidersAndTextBox(Color color)
        {
            var (hue, saturation, value) = ColorToHsv(color);
            HueSlider.Value = hue;
            SaturationSlider.Value = saturation;
            ValueSlider.Value = value;
            OpacitySlider.Value = color.A / 255.0;
            HexCodeTextBox.Text = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }


        private void UpdateTextBox(Color color)
        {
            HexCodeTextBox.TextChanged -= HexCodeTextBox_TextChanged;
            HexCodeTextBox.Text = color.ToString();
            HexCodeTextBox.TextChanged += HexCodeTextBox_TextChanged;
        }

        private static bool IsValidHexCode(string hexCode)
        {
            return hexCode.Length == 7 && hexCode[0] == '#' && int.TryParse(hexCode.Substring(1), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _);

        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte newAlpha = Convert.ToByte(e.NewValue * 255);
            Color currentColor = SelectedColor;
            currentColor.A = newAlpha;
            SelectedColor = currentColor;
        }


        private Color GetColorFromPalette(Point position)
        {
            // Implement your logic to calculate the color based on the position
            // clicked on the palette. This can vary depending on the design of
            // your color palette.
            throw new NotImplementedException("Please implement the GetColorFromPalette method.");
        }

        private static Color ColorFromHsv(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            byte v = Convert.ToByte(value);
            byte p = Convert.ToByte(value * (1 - saturation));
            byte q = Convert.ToByte(value * (1 - f * saturation));
            byte t = Convert.ToByte(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => Color.FromArgb(255, v, t, p),
                1 => Color.FromArgb(255, q, v, p),
                2 => Color.FromArgb(255, p, v, t),
                3 => Color.FromArgb(255, p, q, v),
                4 => Color.FromArgb(255, t, p, v),
                _ => Color.FromArgb(255, v, p, q),
            };
        }

        private static (double hue, double saturation, double value) ColorToHsv(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double chroma = max - min;
            double hue = 0.0;
            double saturation = chroma == 0 ? 0 : chroma / max;
            double value = max;

            if (chroma != 0)
            {
                if (max == r)
                {
                    hue = (g - b) / chroma + (g < b ? 6 : 0);
                }
                else if (max == g)
                {
                    hue = (b - r) / chroma + 2;
                }
                else
                {
                    hue = (r - g) / chroma + 4;
                }

                hue *= 60;
            }

            return (hue, saturation, value);
        }
    }
}
