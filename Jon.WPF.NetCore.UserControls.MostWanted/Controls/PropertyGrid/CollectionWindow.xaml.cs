using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls.PropertyGrid
{
    /// <summary>
    /// Interaction logic for CollectionWindow.xaml
    /// </summary>
    public partial class CollectionWindow : Window
    {
        private List<object> _items { get; set; }
        public ObservableCollection<object> Items { get; set; }

        public CollectionWindow()
        {
            InitializeComponent();
        }

        public CollectionWindow(IEnumerable<object> items)
        {
            _items = new List<object>();
            Items = new ObservableCollection<object>();
            foreach (var item in items)
            {
                _items.Add(item);
                Items.Add(item);
            }
            InitializeComponent();
        }

    }
}