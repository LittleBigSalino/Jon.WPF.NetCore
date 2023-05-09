using Rebus.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for PerformActionConditionalView.xaml
    /// </summary>
    public partial class PerformActionConditionalView : StepBase
    {
        public delegate Task<bool> ExecuteActionDelegate(IProgress<double> progress, IProgress<string> status);
        public delegate bool ConditionDelegate();

        private readonly ExecuteActionDelegate _executeAction;
        private readonly ConditionDelegate _condition;

        public PerformActionConditionalView(ExecuteActionDelegate executeAction, ConditionDelegate condition)
        {
            InitializeComponent();
            _executeAction = executeAction;
            _condition = condition;
        }

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
    }

   
}

