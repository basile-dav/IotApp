using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotApp
{
    internal class Screen
    {
        public bool isOn { get; set; }
        public int seatID { get; }
        public Screen(int seatID) {
            this.seatID = seatID;
        }

        public void displayDialog(string message)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                Thread.Sleep(200); // Attendez 200 millisecondes

                // Décalez le message d'un caractère vers la gauche
                message = message[1..] + message[0];
            }
        }
    }
}
