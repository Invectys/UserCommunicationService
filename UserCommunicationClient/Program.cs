


using Microsoft.AspNetCore.SignalR.Client;
using UserCommunicationClient.api;

Console.WriteLine("Start User communication client");
Console.ReadKey();

HubConnection connection;
connection = new HubConnectionBuilder()
        .WithUrl("http://localhost:5203/hubs/chat")
        .Build();

connection.On<string, string>("NewMessage", (user, message) =>
{
    Console.WriteLine(user + ":" + message);
});

byte[]? pagingState = null;

connection.On<FetchMessagesOutput>("FetchingMessagesHistory", (output) =>
{
    Console.WriteLine("fetched messages");
    pagingState = output.PagingState;
    foreach (var item in output.Messages)
    {
        Console.WriteLine($"{item.CreationTime.ToShortDateString()}: from={item.FromId} to={item.ToId} content={item.Content}");
    }
    
});

await connection.StartAsync();

var uid = "28dafc00-757b-4c89-89a8-5eceb8d7e156";


while (true)
{
    //Console.WriteLine("Write message");
    //var message = Console.ReadLine();
    //if (message == null)
    //    continue;

    //var url = "http://localhost:5203";
    //var input = new SendMessageInput(new Guid(uid), Guid.NewGuid(), message);
    //var client = new HttpClient();
    //client.BaseAddress = new Uri(url);

    //await connection.SendAsync("SendMessage", uid, input);

    Console.WriteLine("Fetch results PRESS ANY KEYS");
    Console.ReadKey();
    var fetch = new FetchMessagesInput(5, pagingState);
    await connection.SendAsync("FetchMessages", fetch);

    //var result = await client.PostAsync("/api/Messages/SendMessage", input.ToHttpContent());
    //var content = result.Content.ReadAsStringAsync().Result;
}
