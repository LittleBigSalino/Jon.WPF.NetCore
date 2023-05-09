using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{

    public abstract class StepBase : UserControl, IStep, INotifyPropertyChanged
    {
        public virtual async Task ExecuteActionAsync()
        {
            // Default implementation, do nothing
            await Task.CompletedTask;
        }

        public virtual int GetNextStepIndex()
        {
            // Default implementation, always go to the next index
            return 1;
        }

        public virtual void StoreSelectedOptions(Dictionary<string, object> selectedOptions)
        {
            // Default implementation, do nothing
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
