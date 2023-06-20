﻿using System;
using System.Threading;

namespace IotApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1er écran :\n1. Entrer dans la salle\n2. Quitter");
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
                        Console.WriteLine("OK");
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }
    }
}