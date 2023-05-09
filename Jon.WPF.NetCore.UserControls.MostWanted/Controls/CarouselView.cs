using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Jon.WPF.NetCore.UserControls.MostWanted.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Jon.WPF.NetCore.UserControls.MostWanted.Controls;assembly=Jon.WPF.NetCore.UserControls.MostWanted.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CarouselView/>
    ///
    /// </summary>
    public class CarouselView : Control
    {
        static CarouselView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CarouselView), new FrameworkPropertyMetadata(typeof(CarouselView)));
        }

        //// Dependency properties declarations
        //public static readonly DependencyProperty ItemsSourceProperty =
        //    DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        //public static readonly DependencyProperty ItemTemplateProperty =
        //    DependencyProperty.Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(null, OnItemTemplateChanged));

        //public static readonly DependencyProperty SelectedItemProperty =
        //    DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(null, OnSelectedItemChanged));

        //public static readonly DependencyProperty SelectedIndexProperty =
        //    DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(0, OnSelectedIndexChanged));

        //public static readonly DependencyProperty OrientationProperty =
        //    DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(Orientation.Horizontal, OnOrientationChanged));

        //public static readonly DependencyProperty TransitionDurationProperty =
        //    DependencyProperty.Register(nameof(TransitionDuration), typeof(TimeSpan), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(TimeSpan.FromSeconds(0.5), OnTransitionDurationChanged));

        //public static readonly DependencyProperty TransitionEasingFunctionProperty =
        //    DependencyProperty.Register(nameof(TransitionEasingFunction), typeof(IEasingFunction), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(new CubicEase { EasingMode = EasingMode.EaseInOut }, OnTransitionEasingFunctionChanged));

        //public static readonly DependencyProperty ItemSpacingProperty =
        //    DependencyProperty.Register(nameof(ItemSpacing), typeof(double), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(0d, OnItemSpacingChanged));

        //public static readonly DependencyProperty ItemScaleFactorProperty =
        //    DependencyProperty.Register(nameof(ItemScaleFactor), typeof(double), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(0.9d, OnItemScaleFactorChanged));

        //public static readonly DependencyProperty IsCyclicProperty =
        //    DependencyProperty.Register(nameof(IsCyclic), typeof(bool), typeof(CarouselView),
        //        new FrameworkPropertyMetadata(false, OnIsCyclicChanged));

        //// Routed events declarations
        //public static readonly RoutedEvent SelectionChangedEvent =
        //    EventManager.RegisterRoutedEvent(nameof(SelectionChanged), RoutingStrategy.Bubble,
        //        typeof(SelectionChangedEventHandler), typeof(CarouselView));

        // CLR properties
        //public IEnumerable ItemsSource
        //{
        //    get => (IEnumerable)GetValue(ItemsSourceProperty);
        //    set => SetValue(ItemsSourceProperty, value);
        //}

        //public DataTemplate ItemTemplate
        //{
        //    get => (DataTemplate)GetValue(ItemTemplateProperty);
        //    set => SetValue(ItemTemplateProperty, value);
        //}

        //public object SelectedItem
        //{
        //    get => GetValue(SelectedItemProperty);
        //    set => SetValue(SelectedItemProperty, value);
        //}

        //public int SelectedIndex
        //{
        //    get => (int)GetValue(SelectedIndexProperty);
        //    set => SetValue(SelectedIndexProperty, value);
        //}

        //public Orientation Orientation
        //{
        //    get => (Orientation)GetValue(OrientationProperty);
        //    set => SetValue(OrientationProperty, value);
        //}

        //public TimeSpan TransitionDuration
        //{
        //    get => (TimeSpan)GetValue(TransitionDurationProperty);
        //    set => SetValue(TransitionDurationProperty, value);
        //}
        //public IEasingFunction TransitionEasingFunction
        //{
        //    get => (IEasingFunction)GetValue(TransitionEasingFunctionProperty);
        //    set => SetValue(TransitionEasingFunctionProperty, value);
        //}
        //public double ItemSpacing
        //{
        //    get => (double)GetValue(ItemSpacingProperty);
        //    set => SetValue(ItemSpacingProperty, value);
        //}

        //public double ItemScaleFactor
        //{
        //    get => (double)GetValue(ItemScaleFactorProperty);
        //    set => SetValue(ItemScaleFactorProperty, value);
        //}

        //public bool IsCyclic
        //{
        //    get => (bool)GetValue(IsCyclicProperty);
        //    set => SetValue(IsCyclicProperty, value);
        //}

        // Property-changed callbacks
        // Property-changed callbacks
        //private static void OnBoolPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as CarouselView;
        //    bool oldValue = (bool)e.OldValue;
        //    bool newValue = (bool)e.NewValue;

        //    // Your implementation for bool property change here.
        //    // For example, you might enable or disable a specific feature in the control.
        //    control.UpdateBoolProperty(newValue);
        //}

        //private static void OnItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnItemTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
        //    }
        //}

        //private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnSelectedItemChanged(e.OldValue, e.NewValue);
        //    }
        //}

        //private static void OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnSelectedIndexChanged((int)e.OldValue, (int)e.NewValue);
        //    }
        //}

        //private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnOrientationChanged((Orientation)e.OldValue, (Orientation)e.NewValue);
        //    }
        //}

        //private static void OnTransitionDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnTransitionDurationChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
        //    }
        //}

        //private static void OnTransitionEasingFunctionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnTransitionEasingFunctionChanged((IEasingFunction)e.OldValue, (IEasingFunction)e.NewValue);
        //    }
        //}

        //private static void OnItemSpacingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnItemSpacingChanged((double)e.OldValue, (double)e.NewValue);
        //    }
        //}

        //private static void OnItemScaleFactorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnItemScaleFactorChanged((double)e.OldValue, (double)e.NewValue);
        //    }
        //}

        //private static void OnIsCyclicChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CarouselView carouselView)
        //    {
        //        carouselView.OnIsCyclicChanged((bool)e.OldValue, (bool)e.NewValue);
        //    }
        //}



        // Other methods and properties remain the same

    }
}
