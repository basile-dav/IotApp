using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotApp
{
    internal class Seat
    {
        /*Attribute*/
        private int roomId;
        public int SeatId { get; }
        public bool IsOccupied { get; set; }
        public bool IsAudioDesc { get;}

        Screen? SeatScreen;

        public string Dialog = "Vous savez, moi je ne crois pas qu’il y ait de bonne ou de mauvaise situation. Moi, si je devais résumer ma vie aujourd’hui avec vous, je dirais que c’est d’abord des rencontres. " +
            "Des gens qui m’ont tendu la main, peut-être à un moment où je ne pouvais pas, où j’étais seul chez moi. Et c’est assez curieux de se dire que les hasards, les rencontres forgent une destinée... " +
            "Parce que quand on a le goût de la chose, quand on a le goût de la chose bien faite, le beau geste, parfois on ne trouve pas l’interlocuteur en face je dirais, le miroir qui vous aide à avancer." +
            " Alors ça n’est pas mon cas, comme je disais là, puisque moi au contraire, j’ai pu ; et je dis merci à la vie, je lui dis merci, je chante la vie, je danse la vie... je ne suis qu’amour ! " +
            "Et finalement, quand des gens me disent « Mais comment fais-tu pour avoir cette humanité ? », je leur réponds très simplement que c’est ce goût de l’amour, ce goût donc qui m’a poussé aujourd’hui à entreprendre une construction mécanique... mais demain qui sait ? " +
            "Peut-être simplement à me mettre au service de la communauté, à faire le don, le don de soi.";
        public Seat(int seatId, int roomNB, bool audioDesc) 
        {
            SeatId = seatId;
            roomId = roomNB;
            IsOccupied = false;
            IsAudioDesc = audioDesc;

            if (IsAudioDesc)
            {
                SeatScreen = new Screen(SeatId);
            }

        }
        

        public void feature()
        {
            if (IsAudioDesc && IsOccupied) {
                if (SeatScreen!=null) {
                    SeatScreen.displayDialog(Dialog);
                }
            }
        }
    }
}
