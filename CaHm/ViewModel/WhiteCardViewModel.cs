
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class WhiteCardViewModel : ViewModelBase
    {
        public string Text { get; set; }
        public bool CanAcceptChildren { get; set; }
        public WhiteCardViewModel(string text)
        {
            Text = text;
        }
    }
}
