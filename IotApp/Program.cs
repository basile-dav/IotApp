using System;
using System.Threading;
using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;
using HiveMQtt.MQTT5.Types;
using System.Text.Json;

namespace IotApp
{
    internal class Program
    {
        async void Main(string[] args)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue :\n1. Entrer dans la salle\n2. Quitter");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Room salle = new Room(1, 30);
                        DisplaySecondScreen(salle);
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Option invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void DisplaySecondScreen(Room room)
        {
            Console.Clear();
            Console.WriteLine("2eme écran :\n1. Siège classique \n2. Siège audiodesc");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Vous avez choisi le Siège classique. Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    break;
                case "2":
                    Seat? desiredSeat = null;
                    foreach (var seat in room.SeatList)
                    {
                        if (!seat.IsOccupied && seat.IsAudioDesc)
                        {
                            desiredSeat = seat;
                        }
                        else
                        {
                            desiredSeat = null;
                        }
                    }
                    if (desiredSeat == null)
                    {
                        Console.WriteLine("Il n'y a pas de siège audio description dans cette salle. Appuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        //TODO
                        DisplayThirdScreen(room, desiredSeat);
                        break;
                    }
                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }

        static async void DisplayThirdScreen(Room room, Seat seat)
        {
            Console.WriteLine("Que souhaitez vous faire :\n1. s'asseoir \n2. Se lever\n3. Partir");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Vous vous s'asseyez...");
                    //var advise = await client.PublishAsync("seat","{'ON'}").ConfigureAwait(false);
                    seat.IsOccupied = true;
                    seat.sit();
                    DisplayThirdScreen(room,seat, );
                    break;
                case "2":
                    Console.WriteLine("Vous êtes debout");
                    //var advise2 = await client.PublishAsync("seat", "{'OFF'}").ConfigureAwait(false);
                    seat.IsOccupied = false;
                    DisplayThirdScreen(room, seat);
                    break;
                case "3":
                    Console.WriteLine("Vous partez de la salle. Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }

      
    }
}