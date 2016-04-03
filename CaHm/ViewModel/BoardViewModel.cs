using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private string m_test;

        public BoardViewModel()
        {

            Test = "Board";
        }
        public string Test
        {
            get
            {
                return m_test;
            }
            set
            {
                m_test = value;
                OnPropertyChanged("Test");
            }
        }
    }
}
