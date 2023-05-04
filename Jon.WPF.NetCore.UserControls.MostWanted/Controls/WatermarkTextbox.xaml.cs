using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for WatermarkTextbox.xaml
    /// </summary>
    public partial class WatermarkTextBox : UserControl
    {
        public WatermarkTextBox()
        {
            InitializeComponent();
            DataContext = this;
            UpdateWatermark();
        }

        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty WatermarkColorProperty =
            DependencyProperty.Register("WatermarkColor", typeof(Brush), typeof(WatermarkTextBox), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty ForegroundColorProperty =
           DependencyProperty.Register("ForegroundColor", typeof(Brush), typeof(WatermarkTextBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(WatermarkTextBox), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkTextBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string WatermarkText
        {
            get => (string)GetValue(WatermarkTextProperty);
            set => SetValue(WatermarkTextProperty, value);
        }

        public Brush WatermarkColor
        {
            get => (Brush)GetValue(WatermarkColorProperty);
            set => SetValue(WatermarkColorProperty, value);
        }

        public Brush ForegroundColor
        {
            get => (Brush)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        public Brush BackgroundColor
        {
            get => (Brush)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void UpdateWatermark()
        {
            WatermarkTextBlock.Visibility = string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            WatermarkTextBlock.Visibility = Visibility.Collapsed;
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                WatermarkTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateWatermark();
        }
    }
}