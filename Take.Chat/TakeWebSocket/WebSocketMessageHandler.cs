using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Take.Chat.Converters;

namespace Take.Chat.TakeWebSocket
{
    public class WebSocketMessageHandler : SocketHandler
    {
        public WebSocketMessageHandler(ConnectionManager connections) : base(connections)
        {
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
        }

        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            await SendMessageToAll(message.ToClientMessage());
        }
    }
}
