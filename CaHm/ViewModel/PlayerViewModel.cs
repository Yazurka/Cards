using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private string m_name;
        private int m_score;

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Score
        {
            get
            {
                return m_score;
            }
            set
            {
                m_score = value;
                OnPropertyChanged("Score");
            }
        }
    }
}
