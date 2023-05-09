using Rebus.Pipeline;
using System;
using System.Collections.Generic;
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

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    /// <summary>
    /// Interaction logic for PerformActionView.xaml
    /// </summary>
    public partial class PerformActionView : StepBase
    {
        public delegate Task<bool> ExecuteActionDelegate(IProgress<double> progress, IProgress<string> status);

        private readonly ExecuteActionDelegate _executeAction;

        public PerformActionView(ExecuteActionDelegate executeAction)
        {
            InitializeComponent();
            _executeAction = executeAction;
        }

        public override async Task ExecuteActionAsync()
        {
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
