using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for PerformActionConditionalView.xaml
    /// </summary>
    public partial class PerformActionConditionalView : StepBase
    {
        public PerformActionConditionalView(ExecuteActionDelegate executeAction, ConditionDelegate condition)
        {
            InitializeComponent();
            _executeAction = executeAction;
            _condition = condition;
        }
        private readonly ExecuteActionDelegate _executeAction;
        private readonly ConditionDelegate _condition;
        public async Task ExecuteActionAsync()
        {
            if (!_condition())
            {
                return;
            }

            var progress = new Progress<double>(percent => ActionProgressBar.Value = percent);
            var status = new Progress<string>(message => ActionStatusTextBlock.Text = message);
            await _executeAction(progress, status);
        }
        public int GetNextStepIndex()
        {
            // Assuming the next step is always the next index, change this as needed
            return 1;
        }
        public void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            throw new NotImplementedException();
        }
        public delegate Task<bool> ExecuteActionDelegate(IProgress<double> progress, IProgress<string> status);
        public delegate bool ConditionDelegate();
    }

}
