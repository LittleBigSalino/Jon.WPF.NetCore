using Rebus.Pipeline;
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

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for SelectOptionView.xaml
    /// </summary>
    public partial class SelectOptionView : StepBase
    {       
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly List<string> _options;
        private readonly Dictionary<string, CheckBox> _optionControls;        

        public SelectOptionView(List<string> options)
        {
            InitializeComponent();

            _options = options;
            _optionControls = new Dictionary<string, CheckBox>();
            GenerateOptionControls();
        }

        private void GenerateOptionControls()
        {
            foreach (var option in _options)
            {
                CheckBox checkBox = new CheckBox
                {                    
                    Content = option,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                _optionControls.Add(option, checkBox);
                OptionStackPanel.Children.Add(checkBox);
            }
        }

        public override void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            foreach (var optionControl in _optionControls)
            {
                if (optionControl.Value.IsChecked == true)
                {
                    selectedOptions.Add(optionControl.Key, optionControl.Value);
                }
            }
        }
    }
}
