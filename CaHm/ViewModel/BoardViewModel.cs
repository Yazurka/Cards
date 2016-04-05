using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.WebSockets;
using System.Net;

namespace CaHm.ViewModel
{
    public class BoardViewModel : ViewModelBase, IDropTarget
    {
        private HubConnection m_hubConnection;
        private IHubProxy m_hubProxy;
        private BlackCardViewModel m_blackCardViewModel;
        private ObservableCollection<WhiteCardViewModel> m_cardsOnHand;
        private ObservableCollection<WhiteCardViewModel> m_cardsOnBoard;
        public  BoardViewModel()
        {
            CardsOnBoard = new ObservableCollection<WhiteCardViewModel>();
            BlackCardViewModel = new BlackCardViewModel();
            generateWhitecardsOnHand();
            generateWhitecardsOnBoard();
            //try
            //{
                var querystringData = new Dictionary<string, string>();
                querystringData.Add("name", "asad");
                querystringData.Add("message", "sdfsdsd");
                m_hubConnection = new HubConnection("http://localhost:8080", querystringData);
                m_hubProxy = m_hubConnection.CreateHubProxy("MyHub");
                m_hubProxy.On<string, string>("Send", lol);
            
                ServicePointManager.DefaultConnectionLimit = 1;
                m_hubConnection.Start().Wait();
                //m_hubProxy.On<string, string>("Send", (name, message) =>
                //{
                //    MessageBox.Show("Name " + name + " Message " + message);
                //});
              
                m_hubConnection.Received += m_hubConnection_Received;
            //}catch(Exception ex){
            //    throw ex;
            //}
            
        }
        private void lol(string name, string message)
        {

        }
        private void m_hubConnection_Received(string obj)
        {
            MessageBox.Show("Recived");
        }
         void IDropTarget.DragOver(IDropInfo dropInfo)
        {

           
            WhiteCardViewModel sourceItem = dropInfo.Data as WhiteCardViewModel;
            WhiteCardViewModel targetItem = dropInfo.TargetItem as WhiteCardViewModel;

            if (sourceItem != null && targetItem != null && targetItem.CanAcceptChildren)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            //var querystringData = new Dictionary<string, string>();
            //querystringData.Add("contosochatversion", "1.0");
            //m_hubConnection.Send(querystringData).Wait();
            WhiteCardViewModel sourceItem = dropInfo.Data as WhiteCardViewModel;
            WhiteCardViewModel targetItem = dropInfo.TargetItem as WhiteCardViewModel;
            this.CardsOnBoard.Add(sourceItem);
            this.CardsOnHand.Remove(sourceItem);
            
        }
        private void generateWhitecardsOnHand()
        {
            CardsOnHand = new ObservableCollection<WhiteCardViewModel>();
            CardsOnHand.Add(new WhiteCardViewModel("The Pope."));
            CardsOnHand.Add(new WhiteCardViewModel("Hitler."));
            CardsOnHand.Add(new WhiteCardViewModel("Dead Babies."));
            CardsOnHand.Add(new WhiteCardViewModel("Expecting a fart but shiting your pants."));
            
        }
        private void generateWhitecardsOnBoard()
        {
            CardsOnBoard = new ObservableCollection<WhiteCardViewModel>();
            CardsOnBoard.Add(new WhiteCardViewModel("YOLo."));
            CardsOnBoard.Add(new WhiteCardViewModel("Ramstein"));
            foreach (var card in CardsOnBoard)
            {
                card.CanAcceptChildren = true;
            }
            //CardsOnBoard.Add(new WhiteCardViewModel("Justin Bieber"));
            //CardsOnBoard.Add(new WhiteCar dViewModel("Shitting ur pants"));
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
