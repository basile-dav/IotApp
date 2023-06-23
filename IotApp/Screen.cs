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

            bool isRunning = true;

            // Exécutez le code dans un autre thread pour pouvoir lire les entrées de l'utilisateur
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (isRunning)
                    {
                        Console.Clear();
                        Console.WriteLine(message);
                        message = message[1..] + message[0];
                    }
                    Thread.Sleep(200);
                }
            });

            // Démarre le thread
            thread.Start();

            while (true)
            {
                // Si une touche a été pressée
                if (Console.KeyAvailable)
                {
                    // Lit la touche
                    var key = Console.ReadKey(true).Key;

                    // Si c'est la touche espace, arrête ou reprend le défilement
                    if (key == ConsoleKey.Spacebar)
                    {
                        isRunning = !isRunning;
                    }
                    else if (key == ConsoleKey.Escape) // Si c'est la touche échapper, termine le programme
                    {
                        
                        break;
                    }
                }
            }
        }
    }
}
