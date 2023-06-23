﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;
using HiveMQtt.MQTT5.Types;

namespace IotApp
{
    internal class MQTTconnector
    {
        HiveMQClientOptions options;
        HiveMQClient client;
        public MQTTconnector()
        {
            options = new HiveMQClientOptions
            {
                Host = "359891db9c344134a67b5ec1e1fbf9a8.s2.eu.hivemq.cloud",
                Port = 8883,
                UseTLS = true,
                UserName = "IotApp",
                Password = "MyPassword1",
            };
            client = new HiveMQClient(options);
        }
        

        public async void connection (HiveMQClientOptions options,HiveMQClient client)
        {
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
        }
    }
}  

