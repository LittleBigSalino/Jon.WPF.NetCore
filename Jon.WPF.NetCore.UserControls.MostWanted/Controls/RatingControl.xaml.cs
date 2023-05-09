using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    public partial class RatingControl : UserControl
    {
        public static readonly DependencyProperty RatingValueProperty =
            DependencyProperty.Register("RatingValue", typeof(double), typeof(RatingControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnRatingValueChanged));

        public static readonly DependencyProperty MaxRatingValueProperty =
            DependencyProperty.Register("MaxRatingValue", typeof(double), typeof(RatingControl),
                new PropertyMetadata(5.0));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RatingControl),
                new PropertyMetadata(false));

        public static readonly DependencyProperty StarSymbolProperty =
            DependencyProperty.Register("StarSymbol", typeof(Geometry), typeof(RatingControl),
                new PropertyMetadata(null));

        public RatingControl()
        {
            InitializeComponent();
            Style RatingStarStyle = TryFindResource("RatingStarStyle") as Style;
            var test = RatingStarStyle.Setters[2];

        }



        public double RatingValue
        {
            get { return (double)GetValue(RatingValueProperty); }
            set { SetValue(RatingValueProperty, value); }
        }

        public double MaxRatingValue
        {
            get { return (double)GetValue(MaxRatingValueProperty); }
            set { SetValue(MaxRatingValueProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public Geometry StarSymbol
        {
            get { return (Geometry)GetValue(StarSymbolProperty); }
            set { SetValue(StarSymbolProperty, value); }
        }

        private static void OnRatingValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RatingControl ratingControl = (RatingControl)d;
            ratingControl.UpdateStars();
            ratingControl.RaiseRatingValueChangedEvent((double)e.OldValue, (double)e.NewValue);
        }

        private void UpdateStars()
        {
            if (IsReadOnly)
            {
                star1.Fill = RatingValue >= 1 ? Brushes.Gold : Brushes.LightGray;
                star2.Fill = RatingValue >= 2 ? Brushes.Gold : Brushes.LightGray;
                star3.Fill = RatingValue >= 3 ? Brushes.Gold : Brushes.LightGray;
                star4.Fill = RatingValue >= 4 ? Brushes.Gold : Brushes.LightGray;
                star5.Fill = RatingValue >= 5 ? Brushes.Gold : Brushes.LightGray;
            }
            else
            {
                star1.Fill = star1.IsMouseOver || RatingValue >= 1 ? Brushes.Gold : Brushes.LightGray;
                star2.Fill = star2.IsMouseOver || RatingValue >= 2 ? Brushes.Gold : Brushes.LightGray;
                star3.Fill = star3.IsMouseOver || RatingValue >= 3 ? Brushes.Gold : Brushes.LightGray;
                star4.Fill = star4.IsMouseOver || RatingValue >= 4 ? Brushes.Gold : Brushes.LightGray;
                star5.Fill = star5.IsMouseOver || RatingValue >= 5 ? Brushes.Gold : Brushes.LightGray;
            }
        }

        private void RaiseRatingValueChangedEvent(double oldValue, double newValue)
        {
            RoutedEventArgs args = new RoutedEventArgs(RatingValueChangedEvent, this);
            args.Source = this;
            args.Handled = false;
            RaiseEvent(args);
        }

        public static readonly RoutedEvent RatingValueChangedEvent =
            EventManager.RegisterRoutedEvent("RatingValueChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<double>), typeof(RatingControl));

        public event RoutedPropertyChangedEventHandler<double> RatingValueChanged
        {
            add { AddHandler(RatingValueChangedEvent, value); }
            remove { RemoveHandler(RatingValueChangedEvent, value); }
        }
        private void Star_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsReadOnly)
            {
                if (sender == star1) RatingValue = 1;
                else if (sender == star2) RatingValue = 2;
                else if (sender == star3) RatingValue = 3;
                else if (sender == star4) RatingValue = 4;
                else if (sender == star5) RatingValue = 5;
            }
        }

        private void Star_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsReadOnly)
            {
                UpdateStars();
            }
        }

        private void Star_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsReadOnly)
            {
                if (sender == star1 && RatingValue == 1) RatingValue = 0;
                else if (sender == star2 && RatingValue == 2) RatingValue = 1;
                else if (sender == star3 && RatingValue == 3) RatingValue = 2;
                else if (sender == star4 && RatingValue == 4) RatingValue = 3;
                else if (sender == star5 && RatingValue == 5) RatingValue = 4;
                else if (sender == star1) RatingValue = 1;
                else if (sender == star2) RatingValue = 2;
                else if (sender == star3) RatingValue = 3;
                else if (sender == star4) RatingValue = 4;
                else if (sender == star5) RatingValue = 5;
            }
        }
    }
}

