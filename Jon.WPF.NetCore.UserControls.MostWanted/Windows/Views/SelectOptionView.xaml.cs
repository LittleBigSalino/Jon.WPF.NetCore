using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    public partial class SelectOptionView : StepBase
    {
        public SelectOptionView(List<string> options)
        {
            InitializeComponent();

            _options = options;
            _optionControls = new Dictionary<string, CheckBox>();
            GenerateOptionControls();
        }
        private readonly List<string> _options;
        private readonly Dictionary<string, CheckBox> _optionControls;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void GenerateOptionControls()
        {
            foreach (var option in _options)
            {
                CheckBox checkBox = new()
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