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


            var options = new HiveMQClientOptions
            {
                Host = "359891db9c344134a67b5ec1e1fbf9a8.s2.eu.hivemq.cloud",
                Port = 8883,
                UseTLS = true,
                UserName = "IotApp",
                Password = "MyPassword1",
            };
            HiveMQClient client = new HiveMQClient(options);

            Console.WriteLine($"Connecting to {options.Host} on port {options.Port} ...");
            // Connect
            HiveMQtt.Client.Results.ConnectResult connectResult;
            try
            {
                connectResult = await client.ConnectAsync().ConfigureAwait(false);
                if (connectResult.ReasonCode == ConnAckReasonCode.Success)
                {
                    Console.WriteLine($"Connect successful: {connectResult}");
                }
                else
                {
                    // FIXME: Add ToString
                    Console.WriteLine($"Connect failed: {connectResult}");
                    Environment.Exit(-1);
                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine($"Error connecting to the MQTT Broker with the following socket error: {e.Message}");
                Environment.Exit(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to the MQTT Broker with the following message: {e.Message}");
                Environment.Exit(-1);
            }



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue :\n1. Entrer dans la salle\n2. Quitter");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Room salle = new Room(1, 30);
                        DisplaySecondScreen(salle, client);
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

        static void DisplaySecondScreen(Room room,HiveMQClient client)
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
                        DisplayThirdScreen(room, desiredSeat,client);
                        break;
                    }
                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }

        static async void DisplayThirdScreen(Room room, Seat seat, HiveMQClient client)
        {
            Console.WriteLine("Que souhaitez vous faire :\n1. s'asseoir \n2. Se lever\n3. Partir");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Vous vous s'asseyez...");
                    var advise = await client.PublishAsync("seat","{'ON'}").ConfigureAwait(false);
                    seat.IsOccupied = true;
                    seat.sit();
                    DisplayThirdScreen(room,seat, client);
                    break;
                case "2":
                    Console.WriteLine("Vous êtes debout");
                    var advise2 = await client.PublishAsync("seat", "{'OFF'}").ConfigureAwait(false);
                    seat.IsOccupied = false;
                    DisplayThirdScreen(room, seat,client);
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