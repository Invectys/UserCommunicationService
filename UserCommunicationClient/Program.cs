
using System.Text.RegularExpressions;
using UserCommunicationClient;

//"28dafc00-757b-4c89-89a8-5eceb8d7e156"

Console.WriteLine("Start User communication client");
Console.WriteLine("Input your uid");

var uid = Console.ReadLine();
if(uid == null)
{
    return;
}

var chatApi = new ChatApi("http://localhost:5203/hubs/chat", uid);
await chatApi.Init();


while (true)
{
    Console.WriteLine("What do u want to do ?");
    Console.WriteLine("SendMessage <toId> <message>");
    Console.WriteLine("FetchMessages <toId>");
    var inputLine = Console.ReadLine();
    if(inputLine == null)
    {
        continue;
    }

    inputLine = Regex.Replace(inputLine, @"\s+", " ").Trim();
    var inputArgs = inputLine.Split(' ');

    if(inputArgs == null || inputArgs.Length == 0)
    {
        continue;
    }

    string GetCommand()
    {
        return inputArgs![0];
    }

    if(GetCommand() == "SendMessage")
    {
        var toId = inputArgs[1];
        var message = inputArgs[2];
        var chatId = inputArgs[3];
        await chatApi.SendMessage(toId: toId, chatId: chatId, message: message);
        continue;
    }

    if(GetCommand() == "FetchMessages")
    {
        var chatId = inputArgs[1];
        await chatApi.FetchMessages(chatId);
        continue;
    }
}
