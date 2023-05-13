using System.Windows;

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