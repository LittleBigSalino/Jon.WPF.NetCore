using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Jon.WPF.NetCore.WpfTestDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public int CurrentBlockSize
        {
            get => _currentBlockSize;
            set
            {
                _currentBlockSize = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            CurrentBlockSize = 10;
            DataContext = this;
        }
        private int _currentBlockSize;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentBlockSize -= 1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentBlockSize += 1;
        }
    }
}