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


        public Seat(int seatId, int roomNB, bool audioDesc) 
        {
            SeatId = seatId;
            roomId = roomNB;
            IsOccupied = false;

        }


    }
}
