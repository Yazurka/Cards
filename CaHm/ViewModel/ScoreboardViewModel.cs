using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class ScoreboardViewModel : ViewModelBase
    {
        private ObservableCollection<PlayerViewModel> m_players;

        public ObservableCollection<PlayerViewModel> Players
        {
            get
            {
                return m_players;
            }
            set
            {
                m_players = value;
                OnPropertyChanged("Players");
            }
        }
    }
}
