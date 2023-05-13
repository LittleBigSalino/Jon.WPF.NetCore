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
using System.Windows.Shapes;

namespace Jon.WPF.NetCore.WpfTestDriver
{
    /// <summary>
    /// Interaction logic for ToggleSwitchWindow.xaml
    /// </summary>
    public partial class ToggleSwitchWindow : Window
    {
        public ToggleSwitchWindow()
        {
            InitializeComponent();
        }

        private void MyCustomControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click", "Success");
        }
    }
}
