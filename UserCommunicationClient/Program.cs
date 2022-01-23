
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.Text.RegularExpressions;
using UserCommunicationClient;

//"28dafc00-757b-4c89-89a8-5eceb8d7e156"

//"28dafc00-757b-4c89-89a8-5eceb8d7e111"

//"28dafc00-757b-4c89-89a8-5eceb8d7e222"

Console.WriteLine("Start User communication client");

Console.ReadLine();

string uid = "iSDoG08pR0R5aenhDVlLAoJmSxz1";

var configFilePath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
if (!string.IsNullOrEmpty(configFilePath))
{
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromFile(configFilePath)
    });
}

var token = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);


var debugUrl = "http://localhost:5023/hubs/chat";
var prodUrl = "http://194.67.104.187:5023/hubs/chat";


var chatApi = new ChatApi(debugUrl, uid, token);
await chatApi.Init();

Console.WriteLine("What do u want to do ?");
Console.WriteLine("SendMessage <message>");
Console.WriteLine("SelectChat <chatId>");
Console.WriteLine("FetchMessages <chatId>");
Console.WriteLine("CreateDialog <userId>");
Console.WriteLine("AddUserToChat <userId> <chatId>");
Console.WriteLine("FetchChats");

string selectedChatId = "";

while (true)
{
    
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

    if(GetCommand() == "SelectChat")
    {
        if (inputArgs.Length != 2)
        {
            Console.WriteLine("Example: SelectChat <chatId>");
            continue;
        }

        selectedChatId = inputArgs[1];
        Console.WriteLine("Selected!");
        continue;
    }

    if(GetCommand() == "DEBUG")
    {
        await chatApi.Stop();
        chatApi = new ChatApi(debugUrl, uid, token);
        await chatApi.Init();
        continue;
    }

    if(GetCommand() == "FetchChats")
    {
        await chatApi.FetchChats(uid);
        continue;
    }

    if (GetCommand() == "AddUserToChat")
    {
        if (inputArgs.Length != 3)
        {
            Console.WriteLine("Example: AddUserToChat <userId> <chatId>");
            continue;
        }

        var userId = inputArgs[1];
        var chatId = inputArgs[2];

        await chatApi.AddUserToChat(userId, new Guid(chatId));
        Console.WriteLine("Added");
    }

    if (GetCommand() == "CreateDialog")
    {
        if(inputArgs.Length != 2)
        {
            Console.WriteLine("Example: CreateDialog <userId>");
            continue;
        }

        var secondUser = inputArgs[1];
        await chatApi.CreateDialog(uid, secondUser);
        Console.WriteLine("Created!");
        continue;
    }

    if (GetCommand() == "SendMessage")
    {
        if(string.IsNullOrEmpty(selectedChatId))
        {
            Console.WriteLine("pls Select chat, example: SelectChat <chatId>");
            continue;
        }

        var message = "";

        if(inputArgs.Length == 1)
        {
            Console.WriteLine("Ok I will pretend to send it");
            continue;
        }

        foreach (var item in inputArgs.Skip(1))
        {
            message += item + " ";
        }

        await chatApi.SendMessage(toId: null, chatId: new Guid(selectedChatId), message: message);
        continue;
    }

    if(GetCommand() == "FetchMessages")
    {
        if (string.IsNullOrEmpty(selectedChatId))
        {
            Console.WriteLine("Select chat");
            continue;
        }
        var chatId = selectedChatId;
        await chatApi.FetchMessages(new Guid(chatId));
        continue;
    }
}
