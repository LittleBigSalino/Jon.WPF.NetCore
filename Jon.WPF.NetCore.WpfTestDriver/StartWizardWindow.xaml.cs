using Jon.WPF.NetCore.UserControls.MostWanted.Windows;
using Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Jon.WPF.NetCore.WpfTestDriver
{
    /// <summary>
    /// Interaction logic for StartWizardWindow.xaml
    /// </summary>
    public partial class StartWizardWindow : Window
    {
        public StartWizardWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> questions = new Dictionary<string, string>();

            questions.Add("Cartoon", "What was your favorite cartoon as a kid?");
            List<StepBase> userControls = new List<StepBase>();
            List<string> options = new List<string>() { "Spacely Sprockets", "Cogsley Cogs" };
            WizardWindowWelcomeView wwwv = new WizardWindowWelcomeView("Welcome to the WizardWindow!","This wizard will guide you through the process of gathering information and then doing something. Ipusm Lorem!.Cheers!"); 
            GatherValuesView gvv = new GatherValuesView(questions);
            SelectOptionView sov = new SelectOptionView(options);
            
            ConfirmationView cv = new ConfirmationView("These are the options you choose");
            PerformActionView performActionView = new PerformActionView(
                async (progress, status) => await CopyLargeFileAsync(progress, status));


            userControls.Add(wwwv);
            userControls.Add(gvv);
            userControls.Add(sov);            
            userControls.Add(cv);
            userControls.Add(performActionView);
            WizardWindow wcw = new WizardWindow(userControls);
            wcw.Show();
        }

        private async Task<bool> CopyLargeFileAsync(IProgress<double> progress, IProgress<string> status)
        {
            int totalChunks = 100;
            string sourcePath = @"C:\source\largeFile.bin";
            string destinationPath = @"C:\destination\largeFile.bin";

            // Update status
            status.Report("Copying large file...");

            for (int i = 0; i < totalChunks; i++)
            {
                // Simulate copying a chunk of the file
                await Task.Delay(500); // Remove this line when using actual file copy logic

                // Report progress
                double currentProgress = (double)(i + 1) / totalChunks * 100;
                progress.Report(currentProgress);
            }

            // Update status
            status.Report("File copy complete.");
            return true;
        }

    }
}
