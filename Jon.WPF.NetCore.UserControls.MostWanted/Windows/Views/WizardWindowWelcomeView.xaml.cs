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
    /// Interaction logic for WizardWindowWelcomeView.xaml
    /// </summary>
    public partial class WizardWindowWelcomeView : StepBase
    {
        public WizardWindowWelcomeView()
        {
            InitializeComponent();
        }

        public WizardWindowWelcomeView(string welcomeText, string messageText) : this()
        {
            WelcomeTextBlockTitle.Text = welcomeText;
            TextBlockWelcomeMessage.Text = messageText;
        }

        public Task ExecuteActionAsync()
        {
            throw new NotImplementedException();
        }

        public int GetNextStepIndex()
        {            
            return 1;
        }

        public void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            throw new NotImplementedException();
        }
    }
}
