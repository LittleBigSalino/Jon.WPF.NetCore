using Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views;
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
using System.Windows.Shapes;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows
{
    /// <summary>
    /// Interaction logic for WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window, INotifyPropertyChanged
    {
        private int _currentStepIndex;
        private readonly List<StepBase> _steps;
        private bool isCurrentScreenValid = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Add a property to store selected options
        private Dictionary<string, object> _selectedOptions;
        public Dictionary<string, object> SelectedOptions
        {
            get => _selectedOptions;
            set
            {
                _selectedOptions = value;
                OnPropertyChanged();
            }
        }   

        public WizardWindow()
        {
            InitializeComponent();
            _steps = new List<StepBase>();
            _currentStepIndex = 0;
            if (_steps.Count > 0)
            {
                UpdateStep();
            }
        }

        public WizardWindow(List<StepBase> screens)
        {
            InitializeComponent();
            _steps = screens;
            SelectedOptions = new Dictionary<string, object>();
            _currentStepIndex = 0;
            if (_steps.Count > 0)
            {
                UpdateStep();
            }
        }

        private async void UpdateStep()
        {
            ContentArea.Content = _steps[_currentStepIndex];
            StepIndicator.Text = $"Step {_currentStepIndex + 1} of {_steps.Count}";

            PreviousButton.IsEnabled = _currentStepIndex > 0;
            NextButton.IsEnabled = _currentStepIndex < _steps.Count - 1;
            FinishButton.IsEnabled = _currentStepIndex == _steps.Count - 1;
            if (_steps[_currentStepIndex] is PerformActionView)
            {
                await _steps[_currentStepIndex].ExecuteActionAsync();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStepIndex > 0)
            {
                _currentStepIndex--;
                UpdateStep();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStepIndex < _steps.Count - 1)
            {
                // Store the selected options from the current step before navigating
                _steps[_currentStepIndex].StoreSelectedOptions(SelectedOptions);

                // Get the next step index based on the current step's logic
                _currentStepIndex += _steps[_currentStepIndex].GetNextStepIndex();
                if(_currentStepIndex == _steps.Count - 2)
                {
                    /// Pass the selected option to the confirmation screen ///
                    if(_steps[_currentStepIndex] is ConfirmationView)
                    {
                        (_steps[_currentStepIndex] as ConfirmationView).SelectedOptions = SelectedOptions;
                    }
                }
                UpdateStep();
            }
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStepIndex == _steps.Count - 1)
            {
                // Perform any final processing and close the wizard.
                Close();
            }
        }
    }
}

