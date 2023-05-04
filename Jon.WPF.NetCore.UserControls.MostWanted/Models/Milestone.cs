using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Models
{
    public class Milestone
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public object AlternativeContent { get; set; }
    }

}
