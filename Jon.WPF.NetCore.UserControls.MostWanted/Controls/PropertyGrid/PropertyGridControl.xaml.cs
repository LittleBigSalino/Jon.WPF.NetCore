using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls.PropertyGrid
{
    public partial class PropertyGridControl : UserControl
    {
        public bool CategorizedView
        {
            get => (bool)GetValue(CategorizedViewProperty);
            set => SetValue(CategorizedViewProperty, value);
        }
        public IEnumerable PropertyEntries
        {
            get => (IEnumerable)GetValue(PropertyEntriesProperty);
            set => SetValue(PropertyEntriesProperty, value);
        }
        public object SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }
        public PropertyGridControl()
        {
            InitializeComponent();
            DataContext = new PropertyGridControlViewModel();
        }

        public static readonly DependencyProperty PropertyEntriesProperty =
        DependencyProperty.Register("PropertyEntries", typeof(IEnumerable), typeof(PropertyGridControl));
        public static readonly DependencyProperty CategorizedViewProperty =
        DependencyProperty.Register("CategorizedView", typeof(bool), typeof(PropertyGridControl), new PropertyMetadata(true, OnCategorizedViewChanged));
        public static readonly DependencyProperty SelectedObjectProperty =
        DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGridControl), new PropertyMetadata(null, OnSelectedObjectChanged));
        private static void OnCategorizedViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PropertyGridControl;
            control?.UpdateGroupDescriptions();
        }
        public Brush CategoryColor
        {
            get { return (Brush)GetValue(CategoryColorProperty); }
            set { SetValue(CategoryColorProperty, value); }
        }
        public static readonly DependencyProperty CategoryColorProperty =
            DependencyProperty.Register(nameof(CategoryColor), typeof(Brush), typeof(PropertyGridControl), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x4E, 0x94, 0xDB))));

        public Brush CategoryForeground
        {
            get { return (Brush)GetValue(CategoryForegroundProperty); }
            set { SetValue(CategoryForegroundProperty, value); }
        }
        public static readonly DependencyProperty CategoryForegroundProperty =
            DependencyProperty.Register(nameof(CategoryForeground), typeof(Brush), typeof(PropertyGridControl), new PropertyMetadata(Brushes.White));


        public Brush CategoryBackground
        {
            get { return (Brush)GetValue(CategoryBackgroundProperty); }
            set { SetValue(CategoryBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CategoryBackgroundProperty =
        DependencyProperty.Register(nameof(CategoryBackground), typeof(Brush), typeof(PropertyGridControl), new PropertyMetadata(Brushes.White));

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PropertyGridControl;
            control?.UpdatePropertyEntries(); // Corrected method name
        }
        private void UpdateGroupDescriptions()
        {
            var collectionViewSource = (CollectionViewSource)this.Resources["GroupedPropertyEntries"];
            var collectionView = collectionViewSource.View;

            collectionView.GroupDescriptions.Clear();
            collectionView.SortDescriptions.Clear();

            if (CategorizedView)
            {
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            }
            else
            {
                collectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }
        private void UpdatePropertyEntries()
        {
            if (SelectedObject != null)
            {
                var properties = TypeDescriptor.GetProperties(SelectedObject);
                var propertyEntries = new List<PropertyEntry>();

                foreach (PropertyDescriptor property in properties)
                {
                    if (property.IsBrowsable)
                    {
                        propertyEntries.Add(new PropertyEntry(property, SelectedObject));
                    }
                }

                PropertyEntries = propertyEntries;
            }
            else
            {
                PropertyEntries = null;
            }
        }

        private void OpenCollectionWindow(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var propertyEntry = button.DataContext as PropertyEntry;
            List<object> passer = new List<object>();
            if (propertyEntry?.Value is IEnumerable collection)
            {
                foreach(var item in collection)
                {
                    passer.Add(item);
                }
                var collectionWindow = new CollectionWindow(passer);
                collectionWindow.ShowDialog();
            }
        }
    
        private void PropertyDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem is PropertyEntry selectedPropertyEntry && !selectedPropertyEntry.IsCategory)
            {
                TextBlockSelectedProperty.Text = selectedPropertyEntry.Name;
                TextBlockSelectedPropertyDescription.Text = selectedPropertyEntry.Description;
            }
            else
            {
                TextBlockSelectedProperty.Text = string.Empty;
                TextBlockSelectedPropertyDescription.Text = string.Empty;
            }
        }

        private void CategorizedToggle_Click(object sender, RoutedEventArgs e)
        {
            if (CategorizedToggle.IsChecked == true)
            {
                TextBlockCategorized.Text = "Categorized";
            }
            else
            {
                TextBlockCategorized.Text = "Alphabetized";
            }


        }
    }

   

}