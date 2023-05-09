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
    /// Interaction logic for GatherValuesView.xaml
    /// </summary>
    public partial class GatherValuesView : StepBase
    {

        private bool _isValidated;
        public bool IsValidated
        {
            get => _isValidated;
            set
            {
                _isValidated = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, string> _selectedOptions;
        public Dictionary<string, string> SelectedOptions
        {
            get => _selectedOptions;
            set
            {
                _selectedOptions = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Dictionary<string, string> _questions;
        private readonly Dictionary<string, TextBox> _inputControls;

        public Dictionary<string, object> InputValues { get; set; }

        public GatherValuesView(Dictionary<string, string> questions)
        {
            InitializeComponent();
            SelectedOptions = new Dictionary<string, string>();
            _questions = questions;
            _inputControls = new Dictionary<string, TextBox>();
            GenerateInputControls();
        }

        private void GenerateInputControls()
        {
            foreach (var question in _questions)
            {
                TextBlock label = new TextBlock
                {
                    Text = question.Value,
                    Margin = new Thickness(5)
                };

                TextBox textBox = new TextBox
                {
                    Name = question.Key,
                    Margin = new Thickness(5)
                };

                _inputControls.Add(question.Key, textBox);

                InputStackPanel.Children.Add(label);
                InputStackPanel.Children.Add(textBox);
            }
        }



        public override int GetNextStepIndex()
        {
            InputValues = new Dictionary<string, object>();

            foreach (var inputControl in _inputControls)
            {
                InputValues.Add(inputControl.Key, inputControl.Value.Text);
            }
            StoreSelectedOptions(InputValues);
            // Assuming the next step is always the next index, change this as needed
            return 1;
        }

        public Task ExecuteActionAsync()
        {
            return Task.CompletedTask;
        }

        public override void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            foreach (var inputControl in _inputControls)
            {
                if(!selectedOptions.ContainsKey(inputControl.Key))
                {
                    selectedOptions.Add(inputControl.Key, inputControl.Value.Text);
                }
                
            }    
        }
    }
}
