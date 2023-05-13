using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls.PropertyGrid
{
    public partial class PropertyGrid : UserControl
    {
        public Brush CategoryColor
        {
            get { return (Brush)GetValue(CategoryColorProperty); }
            set { SetValue(CategoryColorProperty, value); }
        }
        public Brush CategoryForeground
        {
            get { return (Brush)GetValue(CategoryForegroundProperty); }
            set { SetValue(CategoryForegroundProperty, value); }
        }
        public Brush CategoryBackground
        {
            get { return (Brush)GetValue(CategoryBackgroundProperty); }
            set { SetValue(CategoryBackgroundProperty, value); }
        }
        public object SelectedObject
        {
            get { return GetValue(SelectedObjectProperty); }
            set { SetValue(SelectedObjectProperty, value); }
        }
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }
        public Brush HeaderBorderBrush
        {
            get { return (Brush)GetValue(HeaderBorderBrushProperty); }
            set { SetValue(HeaderBorderBrushProperty, value); }
        }
        public PropertyGrid()
        {
            InitializeComponent();
            _propertyGridControlModel = new PropertyGridControlViewModel();
            DataContext = _propertyGridControlModel;
            propertyGridControl.DataContext = _propertyGridControlModel;
        }
        private readonly PropertyGridControlViewModel _propertyGridControlModel;
        public static readonly DependencyProperty CategoryColorProperty =
            DependencyProperty.Register(nameof(CategoryColor), typeof(Brush), typeof(PropertyGrid), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x4E, 0x94, 0xDB))));
        public static readonly DependencyProperty CategoryForegroundProperty =
            DependencyProperty.Register(nameof(CategoryForeground), typeof(Brush), typeof(PropertyGrid), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty CategoryBackgroundProperty =
    DependencyProperty.Register("CategoryBackground", typeof(Brush), typeof(PropertyGrid), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x4E, 0x94, 0xDB))));
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), new PropertyMetadata(null, OnSelectedObjectChanged));
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register(nameof(HeaderBackground), typeof(Brush), typeof(PropertyGrid), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1))));
        public static readonly DependencyProperty HeaderBorderBrushProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrush), typeof(Brush), typeof(PropertyGrid), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x8C, 0x8C, 0x8C))));

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PropertyGrid? propertyGrid = d as PropertyGrid;
            propertyGrid?.UpdateSelectedObject(e.NewValue);
        }

        private void UpdateSelectedObject(object obj)
        {
            _propertyGridControlModel.PropertyEntries.Clear();
            TextBlockObjectTypeName.Text = obj?.GetType().Name ?? "None";
            Type? objectType = obj?.GetType();
            DescriptionAttribute? descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(objectType, typeof(DescriptionAttribute));
            TextBlockDescription.Text = descriptionAttribute?.Description ?? "No description available";

            if (obj != null)
            {
                PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(obj);

                foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors)
                {
                    string category = propertyDescriptor.Category ?? "Other";
                    _propertyGridControlModel.PropertyEntries.Add(new PropertyEntry(propertyDescriptor, obj, category));
                }
            }
        }

    }
}