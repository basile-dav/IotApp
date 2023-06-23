# IotApp
This is a school project emulating audio description seat for theaters.


## Project architecture 
This project is made of two dotnet console :
*  IotApp: which is the core app of the theater
*  MQTTMessageReceiver: which handle the MQTT message retranscription.

## How to run the projects : 
1.  Install dotnet 7.0 (https://dotnet.microsoft.com/en-us/download)
2.  Clone the project
3.  on both console app IotApp &  MQTTMessageReceiver in a terminal run thoses commands:
 ```
dotnet build
dotnet run
```
