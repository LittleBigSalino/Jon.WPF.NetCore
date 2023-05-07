using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

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
            foreach(var item in items)
            {
                _items.Add(item);
                Items.Add(item);
            }
            InitializeComponent();
        }

    }
}
