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
        private int deafPeoplePer = 6;
        private int roomId;
        public int RoomCapacity { get; }
        public List<Seat> SeatList = new List<Seat>();

        public Room(int roomNb, int nbSeat)
        {
            roomId = roomNb;
            RoomCapacity = nbSeat; 

            for (int i = 0; i <= roomNb; i++)
            {
                //use to determine the number of equiped seats 
                if (i%deafPeoplePer == 0)
                {
                    SeatList.Add(new Seat(i,roomNb,true));
                }
                else
                {
                    SeatList.Add(new Seat(i,roomNb,false));
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
