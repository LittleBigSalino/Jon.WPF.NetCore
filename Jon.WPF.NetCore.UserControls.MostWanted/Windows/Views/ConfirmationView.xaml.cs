using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for ConfirmationView.xaml
    /// </summary>
    public partial class ConfirmationView : StepBase
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

        private Dictionary<string, object> _selectedOptions;
        public Dictionary<string, object> SelectedOptions
        {
            get => _selectedOptions;
            set
            {
                _selectedOptions = value;
                OnPropertyChanged();
                SelectedOptionKvps.Clear();
                foreach(string key in _selectedOptions.Keys)
                {
                    SelectedOptionKvps.Add(new KeyValuePair<string, object>(key, _selectedOptions[key]));
                }
            }
        }

        public ObservableCollection<KeyValuePair<string, object>> SelectedOptionKvps { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ConfirmationView(string summaryText)
        {
            InitializeComponent();
            SelectedOptionKvps = new ObservableCollection<KeyValuePair<string, object>>();
            _selectedOptions = new Dictionary<string, object>();
            SummaryTextBlock.Text = summaryText;
            DataContext = this;
        }

        public int GetNextStepIndex()
        {
            // Assuming the next step is always the next index, change this as needed
            return 1;
        }

        public Task ExecuteActionAsync()
        {
            throw new NotImplementedException();
        }

        public void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            throw new NotImplementedException();
        }
    }
}
