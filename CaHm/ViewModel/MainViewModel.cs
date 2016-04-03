using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_content;

        public MainViewModel()
        {
            Content = new BoardViewModel();
        }

        public ViewModelBase Content
        {
            get
            {
                return m_content;
            }
            set
            {
                m_content = value;
                OnPropertyChanged("Content");
            }
        }
    }
}
