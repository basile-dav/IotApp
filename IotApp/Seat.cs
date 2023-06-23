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

        public string Dialog = "Vous savez, moi je ne crois pas qu’il y ait de bonne ou de mauvaise situation. Moi, si je devais résumer ma vie aujourd’hui avec vous, je dirais que c’est d’abord des rencontres. ";
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
        

        public void sit()
        {
            if (IsAudioDesc && IsOccupied) {
                if (SeatScreen!=null) {
                    SeatScreen.displayDialog(Dialog);
                }
            }
        }
    }
}
