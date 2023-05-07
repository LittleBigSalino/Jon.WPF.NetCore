using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    /// <summary>
    /// Interaction logic for ColorPaletteControl.xaml
    /// </summary>
    public partial class ColorPaletteControl : UserControl
    {
        private readonly int _colorResolution = 256;
        private WriteableBitmap? _colorBitmap;

        public ColorPaletteControl()
        {
            InitializeComponent();
            Loaded += ColorPaletteControl_Loaded;
        }

        private void ColorPaletteControl_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateColorPalette();
        }

        public static readonly DependencyProperty BlockWidthProperty =
    DependencyProperty.Register(nameof(BlockWidth), typeof(int), typeof(ColorPaletteControl), new PropertyMetadata(10, OnBlockDimensionsChanged));

        public static readonly DependencyProperty BlockHeightProperty =
            DependencyProperty.Register(nameof(BlockHeight), typeof(int), typeof(ColorPaletteControl), new PropertyMetadata(10, OnBlockDimensionsChanged));

        public int BlockWidth
        {
            get => (int)GetValue(BlockWidthProperty);
            set => SetValue(BlockWidthProperty, value);
        }

        public int BlockHeight
        {
            get => (int)GetValue(BlockHeightProperty);
            set => SetValue(BlockHeightProperty, value);
        }

        public static readonly DependencyProperty SelectedColorProperty =
    DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(ColorPaletteControl), new PropertyMetadata(default(Color)));

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }


        private static void OnBlockDimensionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColorPaletteControl control)
            {
                control.GenerateColorPalette();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GenerateColorPalette()
        {
            int blockWidth = BlockWidth;
            int blockHeight = BlockHeight;
            int blocksPerRow = _colorResolution / blockWidth;
            int blocksPerColumn = _colorResolution / blockHeight;

            _colorBitmap = new WriteableBitmap(_colorResolution, _colorResolution, 96, 96, PixelFormats.Bgra32, null);
            ColorCanvas.Width = _colorResolution;
            ColorCanvas.Height = _colorResolution;

            for (int y = 0; y < blocksPerColumn; y++)
            {
                for (int x = 0; x < blocksPerRow; x++)
                {
                    double hue = 360.0 * x / blocksPerRow;
                    double saturation = 1.0 * y / blocksPerColumn;
                    double lightness = 0.5;

                    Color color = ColorFromHsl(hue, saturation, lightness);

                    for (int px = x * blockWidth; px < (x + 1) * blockWidth; px++)
                    {
                        for (int py = y * blockHeight; py < (y + 1) * blockHeight; py++)
                        {
                            _colorBitmap.SetPixel(px, py, color);
                        }
                    }
                }
            }

            ImageBrush brush = new ImageBrush(_colorBitmap);
            ColorCanvas.Background = brush;
        }

        private Color ColorFromHsl(double h, double s, double l)
        {
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = l - c / 2;

            double r1 = 0, g1 = 0, b1 = 0;

            if (0 <= h && h < 60)
            {
                r1 = c;
                g1 = x;
            }
            else if (60 <= h && h < 120)
            {
                r1 = x;
                g1 = c;
            }
            else if (120 <= h && h < 180)
            {
                g1 = c;
                b1 = x;
            }
            else if (180 <= h && h < 240)
            {
                g1 = x;
                b1 = c;
            }
            else if (240 <= h && h < 300)
            {
                r1 = x;
                b1 = c;
            }
            else if (300 <= h && h < 360)
            {
                r1 = c;
                b1 = x;
            }

            return Color.FromArgb(255, (byte)((r1 + m) * 255), (byte)((g1 + m) * 255), (byte)((b1 + m) * 255));
        }




        //private void GenerateColorPalette()
        //{
        //    _colorBitmap = new WriteableBitmap(_colorResolution, _colorResolution, 96, 96, PixelFormats.Bgra32, null);
        //    ColorCanvas.Width = _colorResolution;
        //    ColorCanvas.Height = _colorResolution;

        //    for (int x = 0; x < _colorResolution; x++)
        //    {
        //        for (int y = 0; y < _colorResolution; y++)
        //        {
        //            byte r = (byte)(x % 256);
        //            byte g = (byte)(y % 256);
        //            byte b = (byte)((x + y) / 2 % 256);
        //            Color color = Color.FromRgb(r, g, b);
        //            _colorBitmap.SetPixel(x, y, color);
        //        }
        //    }

        //    ImageBrush brush = new ImageBrush(_colorBitmap);
        //    ColorCanvas.Background = brush;
        //}


        /// <summary>
        /// Swirly Pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void GenerateColorPalette()
        //{
        //    _colorBitmap = new WriteableBitmap(_colorResolution, _colorResolution, 96, 96, PixelFormats.Bgra32, null);
        //    ColorCanvas.Width = _colorResolution;
        //    ColorCanvas.Height = _colorResolution;

        //    for (int x = 0; x < _colorResolution; x++)
        //    {
        //        for (int y = 0; y < _colorResolution; y++)
        //        {
        //            Color color = Color.FromRgb((byte)(x % 256), (byte)(y % 256), (byte)((x * y) % 256));
        //            _colorBitmap.SetPixel(x, y, color);
        //        }
        //    }

        //    ImageBrush brush = new ImageBrush(_colorBitmap);
        //    ColorCanvas.Background = brush;
        //}

        private void ColorCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(ColorCanvas);
            int x = (int)pos.X;
            int y = (int)pos.Y;

            Color color = _colorBitmap.GetPixel(x, y);
            SelectedColor = color; // Set the SelectedColor property

            string hexColor = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            Clipboard.SetText(hexColor);
        }



        //private void ColorCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Point position = e.GetPosition(ColorCanvas);
        //    int x = (int)position.X;
        //    int y = (int)position.Y;
        //    Color selectedColor = _colorBitmap.GetPixel(x, y);
        //    string hexColor = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";
        //    Clipboard.SetText(hexColor);
        //}
    }
}
