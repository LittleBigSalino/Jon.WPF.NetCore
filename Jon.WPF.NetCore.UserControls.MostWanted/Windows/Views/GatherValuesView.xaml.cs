using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for GatherValuesView.xaml
    /// </summary>
    public partial class GatherValuesView : StepBase
    {
        public bool IsValidated
        {
            get => _isValidated;
            set
            {
                _isValidated = value;
                OnPropertyChanged();
            }
        }
        public Dictionary<string, string> SelectedOptions
        {
            get
            {
                return _selectedOptions;
            }

            set
            {
                _selectedOptions = value;
                OnPropertyChanged();
            }
        }
        public Dictionary<string, object>? InputValues { get; set; }
        public GatherValuesView(Dictionary<string, string> questions)
        {
            InitializeComponent();
            SelectedOptions = new Dictionary<string, string>();
            _questions = questions;
            _inputControls = new Dictionary<string, TextBox>();
            GenerateInputControls();
        }
        private readonly Dictionary<string, string> _questions;
        private readonly Dictionary<string, TextBox> _inputControls;
        private bool _isValidated;
        private Dictionary<string, string>? _selectedOptions;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void GenerateInputControls()
        {
            foreach (var question in _questions)
            {
                TextBlock label = new()
                {
                    Text = question.Value,
                    Margin = new Thickness(5)
                };

                TextBox textBox = new()
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
                if (!selectedOptions.ContainsKey(inputControl.Key))
                {
                    selectedOptions.Add(inputControl.Key, inputControl.Value.Text);
                }

            }
        }
    }
}