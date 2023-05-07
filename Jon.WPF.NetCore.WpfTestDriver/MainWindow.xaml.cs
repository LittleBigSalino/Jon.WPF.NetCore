
using Jon.WPF.NetCore.UserControls.MostWanted.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Jon.WPF.NetCore.WpfTestDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _currentBlockSize;
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
