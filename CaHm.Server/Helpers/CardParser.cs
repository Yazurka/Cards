using CaHm.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaHm.Server.Helpers
{
    public class CardParser
    {
        public List<WhiteCard> GetWhiteCards()
        {
            var whiteCards = new List<WhiteCard>();
            
            string line;
            
            System.IO.StreamReader file =
               new System.IO.StreamReader(Cards.WhiteCards);
            while ((line = file.ReadLine()) != null)
            {
                whiteCards.Add(new WhiteCard { Text = line });
            }

            file.Close();

            return whiteCards;
        }
        public List<BlackCard> GetBlackCards()
        {
            var blackCards = new List<BlackCard>();

            string line;

            System.IO.StreamReader file =
               new System.IO.StreamReader(Cards.BlackCards);
            while ((line = file.ReadLine()) != null)
            {
                blackCards.Add(new BlackCard { Text = line });
            }

            file.Close();

            return blackCards;
        }
    }
}
