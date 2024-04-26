using Microsoft.AspNetCore.SignalR;
using BlazorGroupB.Models;
using System.Diagnostics;

namespace BlazorGroupB.Hubs;

public class ChatHub : Hub
{

    public async Task SendMessage(Messages msg)
    {
        try
        {
            await Clients.All.SendAsync("ReceiveMessage", msg);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
            throw;
        }

    }
}