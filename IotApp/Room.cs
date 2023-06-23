using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotApp
{
    internal class Room
    {
        /*Attribute*/
        private int roomId;
        public int roomCapacity { get; }
        public List<Seat> SeatList = new List<Seat>();

        public Room(int roomNb, int nbSeat)
        {
            roomId = roomNb;
            roomCapacity = nbSeat;
            int numberOfAudioDescSeat = roomCapacity / 6;
            for (int i = 0; i <= roomNb; i++)
            {
               if (i < numberOfAudioDescSeat)
                {
                    SeatList.Add(new Seat(i, roomNb, true));
                }
               else
                {
                    SeatList.Add(new Seat(i, roomNb, false));
                }
            }

        }

        public void getSeats()
        {
            foreach (Seat seat in SeatList)
            {
                if (seat.IsAudioDesc)
                {
                    Console.WriteLine("Equiped");
                }
                else
                {
                    Console.WriteLine("Not equiped");
                }
            }
        }

        

    }
}
