using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Windows.Views
{
    public interface IStep
    {
        Task ExecuteActionAsync();
        int GetNextStepIndex();

        // Add this method to the interface
        void StoreSelectedOptions(Dictionary<string, object> selectedOptions);
    }
}
