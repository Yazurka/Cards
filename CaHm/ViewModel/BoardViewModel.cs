﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private BlackCardViewModel m_blackCardViewModel;
        private ObservableCollection<WhiteCardViewModel> m_cardsOnHand;
        private ObservableCollection<WhiteCardViewModel> m_cardsOnBoard;
        public BoardViewModel()
        {
            CardsOnBoard = new ObservableCollection<WhiteCardViewModel>();
            BlackCardViewModel = new BlackCardViewModel();
            generateWhitecardsOnHand();
            generateWhitecardsOnBoard();
        }
        private void generateWhitecardsOnHand()
        {
            CardsOnHand = new ObservableCollection<WhiteCardViewModel>();
            CardsOnHand.Add(new WhiteCardViewModel("The Pope."));
            CardsOnHand.Add(new WhiteCardViewModel("Hitler."));
            CardsOnHand.Add(new WhiteCardViewModel("Dead Babys."));
            CardsOnHand.Add(new WhiteCardViewModel("Expecting a fart but shiting your pants."));
        }
        private void generateWhitecardsOnBoard()
        {
            CardsOnBoard = new ObservableCollection<WhiteCardViewModel>();
            CardsOnBoard.Add(new WhiteCardViewModel("YOLo."));
            CardsOnBoard.Add(new WhiteCardViewModel("Ramstein"));
            //CardsOnBoard.Add(new WhiteCardViewModel("Justin Bieber"));
            //CardsOnBoard.Add(new WhiteCardViewModel("Shitting ur pants"));
            //CardsOnBoard.Add(new WhiteCardViewModel("YOLo."));
            //CardsOnBoard.Add(new WhiteCardViewModel("Ramstein"));
            //CardsOnBoard.Add(new WhiteCardViewModel("Justin Bieber"));
            //CardsOnBoard.Add(new WhiteCardViewModel("Shitting ur pants"));

        }
        public ObservableCollection<WhiteCardViewModel> CardsOnHand
        {
            get
            {
                return m_cardsOnHand;
            }
            set
            {
                m_cardsOnHand = value;
                OnPropertyChanged("CardsOnHand");
            }
        }
        public ObservableCollection<WhiteCardViewModel> CardsOnBoard
        {
            get
            {
                return m_cardsOnBoard;
            }
            set
            {
                m_cardsOnBoard = value;
                OnPropertyChanged("CardsOnBoard");
            }
        }
        public BlackCardViewModel BlackCardViewModel
        {
            get
            {
                return m_blackCardViewModel;
            }
            set
            {
                m_blackCardViewModel = value;
                OnPropertyChanged("BlackCardViewModel");
            }
        }
    }
}
